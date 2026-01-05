namespace DatingTelegramBot.Exceptions;

public class WrongStateException : Exception
{
    public WrongStateException() { }

    public WrongStateException(string message) : base(message) { }

    public WrongStateException(string message, Exception inner) : base(message, inner) { }
}