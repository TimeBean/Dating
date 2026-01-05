namespace DatingContracts;

public class UpdateUserDto
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int? Age { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
}