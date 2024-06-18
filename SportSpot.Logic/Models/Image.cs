using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mime;

namespace SportSpot.Logic.Models;

public class Image
{
    public Guid Id { get; set; }
    public string? Link { get; set; }
    [ForeignKey("User")] public string? Username { get; set; }
    [ForeignKey("Spot")] public Guid? SpotId { get; set; }
    public User? User { get; set; }
    public Spot? Spot { get; set; }
    public Comment? Comment { get; set; }

    public Image()
    {
    }

    private Image(string? link)
    {
        Link = link;
    }

    public static Image Create(string? link)
    {
        if (string.IsNullOrEmpty(link))
        {
            throw new ArgumentException("Link is invalid");
        }
        return new Image(link);
    }
}