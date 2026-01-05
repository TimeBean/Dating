using DatingTelegramBot.Models;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace DatingTelegramBot.DialogSteps;

public class AskNameStep : IDialogStep
{
    public DialogState State => DialogState.WaitingForName;

    public async Task HandleAsync(ITelegramBotClient bot, UserSession session, Message message, CancellationToken ct)
    {
        session.Name = message.Text;

        session.State = DialogState.WaitingForAge;

        await bot.SendMessage(
            message.Chat.Id,
            $"Приятно познакомиться, {message.Text}! Сколько тебе лет?",
            cancellationToken: ct
        );
    }
}