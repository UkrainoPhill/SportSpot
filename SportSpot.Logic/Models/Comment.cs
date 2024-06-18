using System.ComponentModel.DataAnnotations.Schema;

namespace SportSpot.Logic.Models;

public class Comment
{
    public Guid Id { get; set; }
    public string? Text { get; set; }
    public DateTime Date { get; set; }
    [ForeignKey("User")]
    public string Username { get; set; }
    public User User { get; set; }
    public decimal Rating { get; set; }
    [ForeignKey("Spot")]
    public Guid SpotId { get; set; }
    public Spot Spot { get; set; }
    public List<Image> Images { get; set; }

    public Comment()
    {
    }
    
    private Comment(string? text, DateTime date)
    {
        Text = text;
        Date = date;
    }
    
    public static Comment Create(string? text, DateTime date)
    {
        if (string.IsNullOrEmpty(text) || text.Length > 200 || text.Length < 3)
        {
            throw new ArgumentException("Text is invalid");
        }
        if (date.CompareTo(DateTime.Now.AddHours(1)) > 0 || date.CompareTo(DateTime.Now.AddHours(-1)) < 0)
        {
            throw new ArgumentException("Date is invalid");
        }

        return new Comment(text, date);
    }
}