namespace DatingTelegramBot.Exceptions;

public class UnknownUpdateException : Exception
{
    public UnknownUpdateException() { }

    public UnknownUpdateException(string message) : base(message) { }

    public UnknownUpdateException(string message, Exception inner) : base(message, inner) { }
}