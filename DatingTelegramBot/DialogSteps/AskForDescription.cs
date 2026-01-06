using DatingContracts;
using DatingTelegramBot.Models;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace DatingTelegramBot.DialogSteps;

public class AskForDescription : IDialogStep
{
    public DialogState State => DialogState.WaitingForDescription;
    
    public async Task HandleAsync(ITelegramBotClient bot, UserSession session, Update update, CancellationToken ct)
    {
        if (update.Type != UpdateType.Message)
            return;
        
        session.State = DialogState.None;
        
        session.Description = update.Message!.Text;
        
        await bot.SendMessage(
            update.Message!.Chat.Id,
            $"Данные профиля: \n{session.Name}\n{session.Age}\n{session.Description}\n{session.Latitude} {session.Longitude}",
            cancellationToken: ct
        );
    }
}