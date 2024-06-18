using System.ComponentModel.DataAnnotations;

namespace SportSpot.Logic.Models;

public class Spot
{
    [Key]
    public Guid Id { get;}
    public string? Name { get;}
    public string? Description { get;}
    public string? Coordinates { get; }
    public List<Image> Images { get; set; }
    public decimal Rating { get; set; }
    public List<Comment> Comments { get; set; }
    public List<InterestEnum>? Interests { get;set;}

    public Spot()
    {
    }

    private Spot(string? name, string? description, string? coordinates)
    {
        Name = name;
        Description = description;
        Coordinates = coordinates;
    }

    public static Spot Create(string? name, string? description, string? coordinates)
    {
        if (string.IsNullOrEmpty(name) || name.Length > 50 || name.Length < 2)
        {
            throw new ArgumentException("Name is invalid");
        }
        if (string.IsNullOrEmpty(description) || description.Length > 150)
        {
            throw new ArgumentException("Description is invalid");
        }
        return new Spot(name, description, coordinates);
    }
}