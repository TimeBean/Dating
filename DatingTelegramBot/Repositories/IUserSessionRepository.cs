using DatingTelegramBot.Models;

namespace DatingTelegramBot.Repositories;

public interface IUserSessionRepository
{
    UserSession GetOrCreate(long chatId);

    void Update(UserSession session);
}