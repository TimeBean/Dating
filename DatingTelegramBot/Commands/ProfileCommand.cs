using DatingTelegramBot.Models;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace DatingTelegramBot.Commands;

public class ProfileCommand : ICommand
{
    public string CommandToken => "profile";

    public async Task HandleAsync(ITelegramBotClient bot, UserSession session, Update update, CancellationToken ct)
    {
        var profileText = $"Ваш профиль выглядит так:\n" + 
                          $"{session.Name}, {session.Age} - {session.Description} ";
        
        await bot.SendMessage(
            update.Message!.Chat.Id,
            profileText,
            cancellationToken: ct
        );
    }
}