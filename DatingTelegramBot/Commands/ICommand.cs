using DatingTelegramBot.Models;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace DatingTelegramBot.Commands;

public interface ICommand
{
    string CommandToken { get; }

    Task HandleAsync(ITelegramBotClient bot, UserSession session, Update update, CancellationToken ct);
}