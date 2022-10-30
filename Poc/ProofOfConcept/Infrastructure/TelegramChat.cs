using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types.Enums;
using Montreal.Bot.Poc.Interfaces;
using Montreal.Bot.Poc.Models;

namespace Montreal.Bot.Poc.Infrastructure;

public class TelegramChat : ITelegramChat
{
    private ITelegramBotClient _bot;
    private User _user;
    private CancellationToken _ctn;

    public TelegramChat(ITelegramBotClient bot, User user, CancellationToken ctn)
    {
        _bot = bot;
        _user = user;
        _ctn = ctn;
    }

    private Queue<Message> _recievedMessages = new();
    private Queue<CallbackQuery> _recievedCallbacks = new();
    private Queue<Message> _messagesWithReplyMarkup = new(); //todo: убрать или заменить на _namedSentMessages. Заменяет ли его?
    /// <summary>
    /// UniqueId for step in PersonBehaviour and
    /// </summary>
    private Dictionary<string, SentMessage> _namedSentMessages = new();

    /*-----------------------------------------------------------------------*/

    public void Add(Message message) => _recievedMessages.Enqueue(message);
    public void Add(CallbackQuery callback) => _recievedCallbacks.Enqueue(callback);

    /*-----------------------------------------------------------------------*/

    private IReplyMarkup? CreateNativeButtons(Queue<List<string>>? uniteKeyboard)
    {
        if (uniteKeyboard is null)
            return null;

        var replyKeyboard = new List<List<KeyboardButton>>();
        //todo: временное решение, переосмыслить для 
        //if (uniteKeyboard.Count > 2)
        while (uniteKeyboard.TryDequeue(out var line))
        {
            var row = new List<KeyboardButton>();
            foreach (var element in line)
                row.Add(new KeyboardButton(element));
            replyKeyboard.Add(row);
        }

        if (replyKeyboard.Count == 0)
            return null;
        else
        {
            var rkm = new ReplyKeyboardMarkup(replyKeyboard);
            rkm.ResizeKeyboard = true;
            rkm.OneTimeKeyboard = true;
            return rkm;
        }
    }

    private IReplyMarkup? CreateNativeButtons(Fragment fragment, out List<string>? uniqueId)
    {
        var inlineButtons = fragment?.Buttons?.Where(b => b.Type is ButtonType.InlineLink or ButtonType.InlineTransition or ButtonType.InlineReplace or ButtonType.InlineNotification).GroupBy(b => b.Line);
        if (inlineButtons?.Count() == 0)
        {
            uniqueId = null;
            return null;
        }

        var inlineKeyboard = new List<List<InlineKeyboardButton>>();
        uniqueId = new();
        foreach (var group in inlineButtons ?? Enumerable.Empty<IGrouping<int, Button>>())
        {
            var row = new List<InlineKeyboardButton>();
            foreach (var button in group)
            {
                switch (button.Type)
                {
                    case ButtonType.KeyboardTransition:
                        break;
                    case ButtonType.InlineLink:
                        row.Add(InlineKeyboardButton.WithUrl(button.Label!, button.Link!));
                        break;
                    case ButtonType.InlineTransition:
                        row.Add(InlineKeyboardButton.WithCallbackData(button.Label!, button.UniqueId!));
                        break;
                    case ButtonType.InlineReplace:
                        row.Add(InlineKeyboardButton.WithCallbackData(button.Label!, $"replace {button.UniqueId!}"));
                        uniqueId.Add(button.UniqueId!);
                        break;
                    case ButtonType.InlineNotification:
                        row.Add(InlineKeyboardButton.WithSwitchInlineQuery(button.Label!));
                        break;
                    default:
                        row.Add(InlineKeyboardButton.WithCallbackData("🌐"));
                        break;
                }
            }
            if (row.Count > 0)
                inlineKeyboard.Add(row);
        }

        return inlineKeyboard.Count() > 0 ? new InlineKeyboardMarkup(inlineKeyboard) : null;
    }

    /*-----------------------------------------------------------------------*/

    // public async Task<Message> SendAsync(PreparedFragment fragment);
    public async Task<Message> SendAsync(Fragment fragment, Queue<List<string>>? uniteKeyboard = null, bool clearReplyMarkup = false)
    {
        IReplyMarkup? replyMarkup = null;
        List<string>? uniqueId = null;
        Task<Message>? handler = null;
        FragmentType? fragmentType = null;
        MediaType? mediaType = null;

        if (!clearReplyMarkup)
            replyMarkup = CreateNativeButtons(fragment, out uniqueId) ?? CreateNativeButtons(uniteKeyboard);
        else
            replyMarkup = new ReplyKeyboardRemove();

        switch (fragment.Type)
        {
            case FragmentType.Text:
                handler = _bot.SendTextMessageAsync(_user.Id, fragment.Text!, replyMarkup: replyMarkup, disableNotification: true, parseMode: ParseMode.Html, disableWebPagePreview: true);
                fragmentType = FragmentType.Text;
                break;
            case FragmentType.Media:
                var media = fragment.Media!.First();
                fragmentType = FragmentType.Media;
                mediaType = media.Type;
                handler = media!.Type switch
                {
                    MediaType.Photo => _bot.SendPhotoAsync(_user.Id, media.Photo!.FileId, media?.Caption, replyMarkup: replyMarkup, disableNotification: true, parseMode: ParseMode.Html),

                    MediaType.Sound when media.Sound!.Type == SoundType.Audio
                        => _bot.SendAudioAsync(_user.Id, media.Sound.Audio!.FileId, caption: media?.Caption, replyMarkup: replyMarkup, disableNotification: true, parseMode: ParseMode.Html),

                    MediaType.Sound when media.Sound!.Type == SoundType.Voice
                    => _bot.SendVoiceAsync(_user.Id, media.Sound.Voice!.FileId, caption: media?.Caption, replyMarkup: replyMarkup, disableNotification: true, parseMode: ParseMode.Html),

                    MediaType.Sticker => _bot.SendStickerAsync(_user.Id, media.Sticker!.FileId, disableNotification: true, replyMarkup: replyMarkup, cancellationToken: _ctn),

                    _ => throw new ArgumentException(),
                };
                break;
            case FragmentType.Location:
                fragmentType = FragmentType.Location;
                var spot = fragment.Location;
                if (spot?.Latitude is double latitude && spot?.Longitude is double longtitude)
                    if (spot?.Address is string address && spot?.Label is string label)
                        handler = _bot.SendVenueAsync(_user.Id, latitude, longtitude, label, address, replyMarkup: replyMarkup);
                    else
                        handler = _bot.SendLocationAsync(_user.Id, latitude, longtitude, replyMarkup: replyMarkup, cancellationToken: _ctn);
                break;
            default:
                throw new ArgumentException();
        }

        if (uniqueId is not null && uniqueId.Count > 0 && handler is not null)
        {
            var message = await handler;
            var sentMessage = new SentMessage(fragmentType.Value, mediaType, message.MessageId);
            foreach (var id in uniqueId)
                _namedSentMessages.Add(id, sentMessage);
            return await Task.FromResult<Message>(message);
        }
        else if (handler is not null)
            return await handler;
        else
            throw new ArgumentNullException();
    }

    public async Task<Message> SendAsync(string text) => await _bot.SendTextMessageAsync(_user.Id, text, parseMode: ParseMode.MarkdownV2, cancellationToken: _ctn);

    public async Task SendAsync(Spot spot)
    {
        if (spot.Latitude is double latitude && spot.Longitude is double longtitude)
            if (spot.Address is string address && spot.Label is string label)
                await _bot.SendVenueAsync(_user.Id, latitude, longtitude, label, address);
            else
                await _bot.SendLocationAsync(_user.Id, latitude, longtitude);
    }

    public async Task SendAndDeleteAsync(string text, int delay)
    {
        var message = await _bot.SendTextMessageAsync(_user.Id, text, cancellationToken: _ctn);
        await Task.Delay(TimeSpan.FromSeconds(delay));
        await _bot.DeleteMessageAsync(_user.Id, message.MessageId, _ctn);
    }

    public async Task SendStatusAsync(ChatAction action = ChatAction.Typing) => await _bot.SendChatActionAsync(_user.Id, action, _ctn);

    /*-----------------------------------------------------------------------*/

    public async Task EditAsync(Fragment fragment, string uniqueId)
    {
        if (_namedSentMessages.TryGetValue(uniqueId, out var sentMessage))
        {
            IReplyMarkup? newMarkup = CreateNativeButtons(fragment, out var newUniqueId);

            if (sentMessage.fragmentType == fragment.Type)
            {
                switch (fragment.Type)
                {
                    case FragmentType.Text:
                        await _bot.EditMessageTextAsync(_user.Id, sentMessage.message, fragment.Text!, ParseMode.Html, replyMarkup: newMarkup as InlineKeyboardMarkup, cancellationToken: _ctn);
                        break;
                    case FragmentType.Media:
                        var handler = sentMessage.mediaType! switch
                        {
                            MediaType.Photo => _bot.EditMessageMediaAsync(_user.Id, sentMessage.message, new InputMediaPhoto(fragment.Media!.First().Photo!.FileId), newMarkup as InlineKeyboardMarkup, _ctn),
                            _ => throw new ArgumentException()
                        };
                        await handler;
                        break;
                    case FragmentType.Location:
                        //? нужно ли удалять прошлое сообщение
                        await SendAsync(fragment);
                        break;
                    default:
                        throw new ArgumentException();
                }

                if (newUniqueId is not null)
                    foreach (var id in newUniqueId)
                        _namedSentMessages.Add(id, sentMessage);
            }
            else
            {
                await _bot.DeleteMessageAsync(_user.Id, sentMessage.message, _ctn);
                await SendAsync(fragment);
            }
        }
        await Task.CompletedTask;
    }

    /*-----------------------------------------------------------------------*/

    public async Task DeleteRecievedMessageAsync()
    {
        if (_recievedMessages.TryDequeue(out var message))
            await _bot.DeleteMessageAsync(_user.Id, message.MessageId);
    }

    public async Task ClearMessageButtons()
    {
        while (_messagesWithReplyMarkup.TryDequeue(out var message))
            await _bot.EditMessageReplyMarkupAsync(_user.Id, message.MessageId, replyMarkup: null, _ctn);
        _messagesWithReplyMarkup.Clear();
    }
}