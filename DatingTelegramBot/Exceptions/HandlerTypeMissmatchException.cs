namespace DatingTelegramBot.Exceptions;

public class HandlerTypeMissmatchException : Exception
{
    public HandlerTypeMissmatchException() { }

    public HandlerTypeMissmatchException(string message) : base(message) { }

    public HandlerTypeMissmatchException(string message, Exception inner) : base(message, inner) { }
}