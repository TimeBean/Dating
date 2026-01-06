using DatingTelegramBot.DialogSteps;
using DatingTelegramBot.Exceptions;
using DatingTelegramBot.Repositories;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace DatingTelegramBot.Handlers;

public class DialogHandler : IMessageHandler
{
    private readonly IEnumerable<IDialogStep> _steps; 
    private readonly IUserSessionRepository _repository;

    public DialogHandler(IEnumerable<IDialogStep> steps, IUserSessionRepository repository)
    {
        _steps = steps;
        _repository = repository;
    }

    public async Task HandleAsync(ITelegramBotClient bot, Update update, CancellationToken ct)
    {
        long chatId;

        if (update.Type == UpdateType.Message)
        {
            chatId = update.Message!.Chat.Id;
        }
        else if (update.Type == UpdateType.CallbackQuery)
        {
            chatId = update.CallbackQuery!.From.Id;
        }
        else
        {
            throw new UnknownUpdateException();
        }
        
        var session = await _repository.GetOrCreate(chatId);
        
        var step = _steps.FirstOrDefault(s => s.State == session.State);

        if (step == null)
        {
            step = new AskNameStep();
        }
        
        await step.HandleAsync(bot, session, update, ct);

        await _repository.Update(session);
    }
}