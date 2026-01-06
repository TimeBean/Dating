using DatingContracts;
using Telegram.Bot;
using Telegram.Bot.Types;
using DatingTelegramBot.Models;

namespace DatingTelegramBot.DialogSteps;

public interface IDialogStep
{
    DialogState State { get; }

    Task HandleAsync(ITelegramBotClient bot, UserSession session, Update update, CancellationToken ct);
}

