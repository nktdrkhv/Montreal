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
    private Queue<Message> _messagesWithInlineKeyboard = new();
    private Dictionary<string, Message> _namedSentMessages = new();

    public void Add(Message message) => _recievedMessages.Enqueue(message);
    public void Add(CallbackQuery callback) => _recievedCallbacks.Enqueue(callback);

    private IReplyMarkup? CreateConcreteButtons(Queue<List<string>>? uniteKeyboard)
    {
        if (uniteKeyboard is null)
            return null;

        var replyKeyboard = new List<List<KeyboardButton>>();
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

    private IReplyMarkup? CreateConcreteButtons(Fragment fragment)
    {
        // if (fragment?.Buttons?.First()?.Type == ButtonType.RemoveKayboard)
        //     return new ReplyKeyboardRemove();

        var inlineButtons = fragment?.Buttons?.Where(b => b.Type is ButtonType.InlineLink or ButtonType.InlineTransition).GroupBy(b => b.Line);
        if (inlineButtons?.Count() == 0)
            return null;

        var inlineKeyboard = new List<List<InlineKeyboardButton>>();
        foreach (var group in inlineButtons ?? Enumerable.Empty<IGrouping<int, Button>>())
        {
            var row = new List<InlineKeyboardButton>();
            foreach (var button in group)
            {
                var concreteButton = button.Type switch
                {
                    ButtonType.InlineLink => InlineKeyboardButton.WithUrl(button.Label!, button.Link!),
                    ButtonType.InlineTransition => InlineKeyboardButton.WithCallbackData(button.Label!),
                    _ => InlineKeyboardButton.WithCallbackData("🌐"),
                };
                row.Add(concreteButton);
            }
            if (row.Count > 0)
                inlineKeyboard.Add(row);
        }

        return inlineKeyboard.Count() > 0 ? new InlineKeyboardMarkup(inlineKeyboard) : null;
    }

    public async Task<Message> SendAsync(Fragment fragment, Queue<List<string>>? uniteKeyboard = null, bool clearReplyMarkup = false)
    {
        IReplyMarkup? replyMarkup;
        if (!clearReplyMarkup)
            replyMarkup = CreateConcreteButtons(fragment) ?? CreateConcreteButtons(uniteKeyboard);
        else
            replyMarkup = new ReplyKeyboardRemove();

        switch (fragment.Type)
        {
            case FragmentType.Text:
                return await _bot.SendTextMessageAsync(_user.Id, fragment.Text!, replyMarkup: replyMarkup, disableNotification: true);
            case FragmentType.Media:
                var media = fragment.Media!.First();
                var handler = media!.Type switch
                {
                    MediaType.Photo => _bot.SendPhotoAsync(_user.Id, media.Photo!.FileId, media.Caption, replyMarkup: replyMarkup, disableNotification: true),
                    MediaType.Sound when media.Sound!.Type == SoundType.Audio
                        => _bot.SendAudioAsync(_user.Id, media.Sound.Audio!.FileId, replyMarkup: replyMarkup, disableNotification: true),
                    _ => throw new ArgumentException(),
                };
                return await handler;
            default:
                throw new ArgumentException();
        }
    }

    public async Task<Message> SendAsync(string text) => await _bot.SendTextMessageAsync(_user.Id, text, parseMode: ParseMode.MarkdownV2, cancellationToken: _ctn);

    public async Task SendAndDeleteAsync(string text, int delay)
    {
        var message = await _bot.SendTextMessageAsync(_user.Id, text, cancellationToken: _ctn);
        await Task.Delay(TimeSpan.FromSeconds(delay));
        await _bot.DeleteMessageAsync(_user.Id, message.MessageId, _ctn);
    }

    public async Task SendStatusAsync(ChatAction action = ChatAction.Typing) => await _bot.SendChatActionAsync(_user.Id, action, _ctn);

    public async Task DeleteRecievedMessageAsync()
    {
        if (_recievedMessages.TryDequeue(out var message))
            await _bot.DeleteMessageAsync(_user.Id, message.MessageId);
    }

    public async Task ClearMessageButtons()
    {
        while (_messagesWithInlineKeyboard.TryDequeue(out var message))
            await _bot.EditMessageReplyMarkupAsync(_user.Id, message.MessageId, replyMarkup: null, _ctn);
        _messagesWithInlineKeyboard.Clear();
    }
}