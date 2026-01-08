using DatingTelegramBot.Exceptions;
using Telegram.Bot.Types;

namespace DatingTelegramBot.Extensions;

public static class UpdateExtensions
{
    public static long GetChatId(this Update update) => update switch
    {
        { Message: not null } => update.Message.Chat.Id,
        { CallbackQuery: not null } => update.CallbackQuery.From.Id,
        _ => throw new UnknownUpdateException()
    };
}
