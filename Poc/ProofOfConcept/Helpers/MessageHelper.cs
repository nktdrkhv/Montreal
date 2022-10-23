using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Montreal.Bot.Poc.Models;
using Montreal.Bot.Poc.Infrastructure;

namespace Montreal.Bot.Poc.Helpers;

public static class MessageHelper
{
    public static Command? ExtractCommand(Message message)
    {
        var cmdEntity = message?.Entities?[0];
        if (cmdEntity?.Type is MessageEntityType.BotCommand && cmdEntity.Offset is 0)
        {
            var command = message!.Text!.Substring(cmdEntity!.Offset, cmdEntity!.Length);
            var arguments = message!.Text!.Replace(command, string.Empty).Trim();

            return command switch
            {
                "/start" => new Command() { Name = "start", Arguments = arguments },
                _ => null
            };
        }
        else
            return null;
    }

    public static string? ExtractText(Message message) => message.Type is MessageType.Text ? message?.Text : null;

    public static Media? ExtractMedia(Message message)
    {
        var caption = message?.Caption;
        var media = message!.Type switch
        {
            MessageType.Photo => new Media() { Type = MediaType.Photo, Photo = message.Photo![^1], Caption = caption },
            MessageType.Audio => new Media() { Type = MediaType.Sound, Sound = new() { Type = SoundType.Audio, Audio = message.Audio }, Caption = caption },
            MessageType.Voice => new Media() { Type = MediaType.Sound, Sound = new() { Type = SoundType.Voice, Voice = message.Voice }, Caption = caption },
            MessageType.VideoNote => new Media() { Type = MediaType.VideoNote, VideoNote = message.VideoNote, Caption = caption },
            MessageType.Video => new Media() { Type = MediaType.Video, Video = message.Video, Caption = caption },
            MessageType.Sticker => new Media() { Type = MediaType.Sticker, Sticker = message.Sticker, Caption = caption },
            MessageType.Unknown or _ => null,
        };
        return media;
    }

    public static Spot? ExtractSpot(Message message)
    {
        if (message?.Venue is Venue venue)
            return new Spot()
            {
                Accuracy = venue.Location.HorizontalAccuracy,
                Latitude = venue.Location.Latitude,
                Longitude = venue.Location.Longitude,
                Label = venue.Title,
                Address = venue.Address
            };
        else if (message?.Location is Location location)
            return new Spot()
            {
                Accuracy = location.HorizontalAccuracy,
                Latitude = location.Latitude,
                Longitude = location.Longitude,
            };
        else
            return null;
    }
}