using DatingContracts;
using DatingTelegramBot.Models;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace DatingTelegramBot.DialogSteps;

public class AskAgeStep : IDialogStep
{
    public DialogState State => DialogState.WaitingForAge;

    public async Task HandleAsync(ITelegramBotClient bot, UserSession session, Update update, CancellationToken ct)
    {
        if (update.Type != UpdateType.Message)
            return;
        
        session.Age = int.Parse(update.Message!.Text!);

        session.State = DialogState.WaitingForPlace;

        await bot.SendMessage(
            update.Message.Chat.Id,
            $"Ясно, {session.Name}. Тебе {session.Age} лет. Откуда ты?",
            cancellationToken: ct
        );
    }
}