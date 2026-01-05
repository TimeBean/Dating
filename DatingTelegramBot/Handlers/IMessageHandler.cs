namespace DatingTelegramBot.Handlers;

using Telegram.Bot;
using Telegram.Bot.Types;
using System.Threading;
using System.Threading.Tasks;

public interface IMessageHandler
{
    Task HandleAsync(ITelegramBotClient bot, Message message, CancellationToken cancellationToken);
}