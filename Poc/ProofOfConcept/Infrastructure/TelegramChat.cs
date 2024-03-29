using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types.Enums;
using Montreal.Bot.Poc.Interfaces;
using Montreal.Bot.Poc.Models;

namespace Montreal.Bot.Poc.Infrastructure;

public class TelegramChat : ITelegramChat
{
    public string Me() => $"{_user.Id} = {_user.FirstName}";

    public ITelegramBotClient Bot { get; set; }
    private User _user;
    private CancellationToken _ctn;

    public TelegramChat(ITelegramBotClient bot, User user, CancellationToken ctn)
    {
        Bot = bot;
        _user = user;
        _ctn = ctn;
    }

    //private int _lastNextMessageId;
    private Queue<Message> _recievedMessages = new();
    private Queue<CallbackQuery> _recievedCallbacks = new();
    // private Queue<Message> _messagesWithReplyMarkup = new(); //todo: убрать или заменить на _namedSentMessages. Заменяет ли его?

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
        //todo: временное решение, переосмыслить
        //---//
        if (uniteKeyboard.TryPeek(out var first) && first.Count > 2)
        {
            foreach (var label in first)
                replyKeyboard.Add(new() { label });
        }
        else
        {
            while (uniteKeyboard.TryDequeue(out var line))
            {
                var row = new List<KeyboardButton>();
                foreach (var element in line)
                    row.Add(new KeyboardButton(element));
                replyKeyboard.Add(row);
            }
        }
        //---//

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

    private IReplyMarkup? CreateNativeButtons(Fragment fragment, out List<string>? uniqueId, out bool done)
    {
        var inlineButtons = fragment?.Buttons?.Where(b => b.Type is ButtonType.InlineLink or ButtonType.InlineTransition or ButtonType.InlineReplace or ButtonType.InlineNotification or ButtonType.InlinePause).GroupBy(b => b.Line);
        if (inlineButtons?.Count() == 0)
        {
            uniqueId = null;
            done = false;
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
                    case ButtonType.InlinePause:
                        row.Add(InlineKeyboardButton.WithCallbackData(button.Label ?? "Далее", "next"));
                        uniqueId.Add(button.UniqueId!);
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

        done = true;
        return inlineKeyboard.Count() > 0 ? new InlineKeyboardMarkup(inlineKeyboard) : null;
    }

    /*-----------------------------------------------------------------------*/

    // public async Task<Message> SendAsync(PreparedFragment fragment);
    public async Task<Message> SendAsync(Fragment fragment, Queue<List<string>>? uniteKeyboard = null, bool clearReplyMarkup = false, bool pin = false)
    {
        IReplyMarkup? replyMarkup = null;
        List<string>? uniqueId = null;
        Task<Message>? handler = null;
        FragmentType? fragmentType = null;
        MediaType? mediaType = null;

        if (!clearReplyMarkup)
            replyMarkup = CreateNativeButtons(fragment, out uniqueId, out _) ?? CreateNativeButtons(uniteKeyboard);
        else
            replyMarkup = new ReplyKeyboardRemove();

        // var replyMarkupAfter = CreateNativeButtons(fragment, out uniqueId, out var isInline) ?? CreateNativeButtons(uniteKeyboard);
        // if (isInline)
        //     replyMarkup = new ReplyKeyboardRemove();
        // else
        //     replyMarkup = replyMarkupAfter;

        //Message message;

        switch (fragment.Type)
        {
            case FragmentType.Text:
                handler = Bot.SendTextMessageAsync(_user.Id, fragment.Text!, replyMarkup: replyMarkup, disableNotification: true, parseMode: ParseMode.Html, disableWebPagePreview: true);
                fragmentType = FragmentType.Text;
                break;
            case FragmentType.Media:
                var media = fragment.Media!.First();
                fragmentType = FragmentType.Media;
                mediaType = media.Type;
                handler = media!.Type switch
                {
                    MediaType.Photo => Bot.SendPhotoAsync(_user.Id, media.Photo!.FileId, media?.Caption, replyMarkup: replyMarkup, disableNotification: true, parseMode: ParseMode.Html),

                    MediaType.Sound when media.Sound!.Type == SoundType.Audio
                        => Bot.SendAudioAsync(_user.Id, media.Sound.Audio!.FileId, caption: media?.Caption, replyMarkup: replyMarkup, disableNotification: true, parseMode: ParseMode.Html),

                    MediaType.Sound when media.Sound!.Type == SoundType.Voice
                    => Bot.SendVoiceAsync(_user.Id, media.Sound.Voice!.FileId, caption: media?.Caption, replyMarkup: replyMarkup, disableNotification: true, parseMode: ParseMode.Html),

                    MediaType.Sticker => Bot.SendStickerAsync(_user.Id, media.Sticker!.FileId, disableNotification: true, replyMarkup: replyMarkup, cancellationToken: _ctn),

                    _ => throw new ArgumentException(),
                };
                break;
            case FragmentType.Location:
                fragmentType = FragmentType.Location;
                var spot = fragment.Location;
                if (spot?.Latitude is double latitude && spot?.Longitude is double longtitude)
                    if (spot?.Address is string address && spot?.Label is string label)
                        handler = Bot.SendVenueAsync(_user.Id, latitude, longtitude, label, address, replyMarkup: replyMarkup);
                    else
                        handler = Bot.SendLocationAsync(_user.Id, latitude, longtitude, replyMarkup: replyMarkup, cancellationToken: _ctn);
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

            // if (isInline && replyMarkupAfter is not null)
            //     //await _bot.EditMessageTextAsync()
            //     await _bot.EditMessageReplyMarkupAsync(_user.Id, message.MessageId, replyMarkupAfter as InlineKeyboardMarkup, _ctn);

            if (pin) await Bot.PinChatMessageAsync(_user.Id, message.MessageId, true, _ctn);
            return await Task.FromResult<Message>(message);
        }
        else if (handler is not null)
        {
            var message = await handler;

            // if (isInline && replyMarkupAfter is not null)
            //     await _bot.EditMessageReplyMarkupAsync(_user.Id, message.MessageId, replyMarkupAfter as InlineKeyboardMarkup, _ctn);

            if (pin) await Bot.PinChatMessageAsync(_user.Id, message.MessageId, true, _ctn);
            return await Task.FromResult<Message>(message);
        }
        else
            throw new ArgumentNullException();
    }

    public async Task<Message> SendAsync(string text) => await Bot.SendTextMessageAsync(_user.Id, text, parseMode: ParseMode.MarkdownV2, cancellationToken: _ctn);

    public async Task SendAsync(Spot spot)
    {
        if (spot.Latitude is double latitude && spot.Longitude is double longtitude)
            if (spot.Address is string address && spot.Label is string label)
                await Bot.SendVenueAsync(_user.Id, latitude, longtitude, label, address);
            else
                await Bot.SendLocationAsync(_user.Id, latitude, longtitude);
    }

    public async Task SendAndDeleteAsync(string text, int delay)
    {
        var message = await Bot.SendTextMessageAsync(_user.Id, text, cancellationToken: _ctn);
        await Task.Delay(TimeSpan.FromSeconds(delay));
        await Bot.DeleteMessageAsync(_user.Id, message.MessageId, _ctn);
    }

    public async Task SendStatusAsync(ChatAction action = ChatAction.Typing) => await Bot.SendChatActionAsync(_user.Id, action, _ctn);

    /*-----------------------------------------------------------------------*/

    public async Task EditAsync(Fragment fragment, string uniqueId)
    {
        if (_namedSentMessages.TryGetValue(uniqueId, out var sentMessage))
        {
            IReplyMarkup? newMarkup = CreateNativeButtons(fragment, out var newUniqueId, out _);

            if (sentMessage.fragmentType == fragment.Type)
            {
                switch (fragment.Type)
                {
                    case FragmentType.Text:
                        await Bot.EditMessageTextAsync(_user.Id, sentMessage.message, fragment.Text!, ParseMode.Html, replyMarkup: newMarkup as InlineKeyboardMarkup, cancellationToken: _ctn);
                        break;
                    case FragmentType.Media:
                        var media = fragment.Media!.First();
                        switch (sentMessage.mediaType!)
                        {
                            case MediaType.Photo:
                                await Bot.EditMessageMediaAsync(_user.Id, sentMessage.message, new InputMediaPhoto(media.Photo!.FileId), newMarkup as InlineKeyboardMarkup, _ctn);
                                await Bot.EditMessageCaptionAsync(_user.Id, sentMessage.message, media.Caption, ParseMode.Html, replyMarkup: newMarkup as InlineKeyboardMarkup);
                                break;
                            default:
                                throw new ArgumentException();
                        }
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
                await Bot.DeleteMessageAsync(_user.Id, sentMessage.message, _ctn);
                await SendAsync(fragment);
            }
        }
        await Task.CompletedTask;
    }

    /*-----------------------------------------------------------------------*/

    public async Task DeleteRecievedMessageAsync()
    {
        if (_recievedMessages.TryDequeue(out var message))
            await Bot.DeleteMessageAsync(_user.Id, message.MessageId);
    }

    public async Task ClearMessageButtons()
    {
        /*while (_messagesWithReplyMarkup.TryDequeue(out var message))
            await _bot.EditMessageReplyMarkupAsync(_user.Id, message.MessageId, replyMarkup: null, _ctn);
        _messagesWithReplyMarkup.Clear();*/
        foreach (var namedMessage in _namedSentMessages.Values.DistinctBy(sm => sm.message))
        {
            try
            {
                await Bot.EditMessageReplyMarkupAsync(_user!.Id, namedMessage.message, null, _ctn);
            }
            catch { }
        }
        _namedSentMessages.Clear();
    }

    public async Task UnpinAll() => await Bot.UnpinAllChatMessages(_user.Id, _ctn);
}