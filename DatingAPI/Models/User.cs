namespace DatingAPI.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; } = string.Empty; 
    public int Age { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
}