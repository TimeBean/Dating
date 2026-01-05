namespace DatingTelegramBot.Models;

public class UserSession
{
    public long ChatId { get; set; }
    
    public DialogState State { get; set; } = DialogState.None;

    public string? Name { get; set; }
    public int? Age { get; set; }

    public Dictionary<string, string> TempData { get; set; } = new();
}