namespace DatingTelegramBot.Handlers;

using Telegram.Bot;
using Telegram.Bot.Types;
using System.Threading;
using System.Threading.Tasks;

public interface ICommandHandler
{
    Task HandleAsync(ITelegramBotClient bot, Update update, CancellationToken cancellationToken);
}