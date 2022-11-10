using System;
using System.IO;
using Telegram.Bot;
using Telegram.Bot.Types;
using Montreal.Bot.Poc.Models;

namespace Montreal.Bot.Poc.Helpers;

public static class FileHelper
{
    public static async void BackupFiles(ITelegramBotClient bot)
    {
        var botData = await bot.GetMeAsync();
        using var repo = new BotDbContext();

        foreach (var file in repo.Media.ToList())
        {
            try
            {
                switch (file.Type)
                {
                    case Infrastructure.MediaType.Photo:
                        var pathPhoto = Path.Combine("Files", "Media", "Photos", $"{Guid.NewGuid().ToString()[..7]}.jpg");
                        var fsPhoto = System.IO.File.OpenWrite(pathPhoto);
                        await bot.GetInfoAndDownloadFileAsync(fileId: file.Photo!.FileId, destination: fsPhoto);
                        var fiPhoto = new FileIdentity() { TelegramBot = botData.Username!, LocalPath = pathPhoto, TelegramFileId = file.Photo!.FileId };
                        repo.FileIdentities.Add(fiPhoto);
                        await fsPhoto.DisposeAsync();
                        break;
                    case Infrastructure.MediaType.Sound:
                        switch (file.Sound!.Type)
                        {
                            case Infrastructure.SoundType.Audio:
                                var pathAudio = Path.Combine("Files", "Media", "Audios", $"{Guid.NewGuid().ToString()[..7]}.mp3");
                                var fsAudio = System.IO.File.OpenWrite(pathAudio);
                                await bot.GetInfoAndDownloadFileAsync(fileId: file.Sound.Audio!.FileId, destination: fsAudio);
                                var fiAudio = new FileIdentity() { TelegramBot = botData.Username!, LocalPath = pathAudio, TelegramFileId = file.Sound.Audio!.FileId };
                                repo.FileIdentities.Add(fiAudio);
                                await fsAudio.DisposeAsync();
                                break;
                            case Infrastructure.SoundType.Voice:
                                var pathVoice = Path.Combine("Files", "Media", "Voices", $"{Guid.NewGuid().ToString()[..7]}.ogg");
                                var fsVoice = System.IO.File.OpenWrite(pathVoice);
                                await bot.GetInfoAndDownloadFileAsync(fileId: file.Sound.Voice!.FileId, destination: fsVoice);
                                var fiVoice = new FileIdentity() { TelegramBot = botData.Username!, LocalPath = pathVoice, TelegramFileId = file.Sound.Voice!.FileId };
                                repo.FileIdentities.Add(fiVoice);
                                await fsVoice.DisposeAsync();
                                break;
                            default:
                                break;
                        }
                        break;
                    case Infrastructure.MediaType.Sticker:
                        var pathSticker = Path.Combine("Files", "Media", "Stickers", $"{Guid.NewGuid().ToString()[..7]}.webp");
                        var fsSticker = System.IO.File.OpenWrite(pathSticker);
                        await bot.GetInfoAndDownloadFileAsync(fileId: file.Sticker!.FileId, destination: fsSticker);
                        var fiSticker = new FileIdentity() { TelegramBot = botData.Username!, LocalPath = pathSticker, TelegramFileId = file.Sticker!.FileId };
                        repo.FileIdentities.Add(fiSticker);
                        await fsSticker.DisposeAsync();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        repo.SaveChanges();
    }

    public static void RestoreFiles(ITelegramBotClient bot)
    {
        //using var repo = new BotDbContext();
    }
}