using System.Collections.Concurrent;
using DatingTelegramBot.Models;

namespace DatingTelegramBot.Repositories;

public class InMemorySessionRepository : IUserSessionRepository
{
    private readonly ConcurrentDictionary<long, UserSession> _sessions = new();

    public UserSession GetOrCreate(long chatId)
    {
        return _sessions.GetOrAdd(chatId, id => new UserSession
        {
            ChatId = id,
            State = DialogState.None
        });
    }

    public void Update(UserSession session)
    {
        _sessions[session.ChatId] = session;
    }
}