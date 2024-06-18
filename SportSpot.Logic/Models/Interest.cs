using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportSpot.Logic.Models;

public class Interest
{
    [Key]
    public Guid Id { get; set; }
    [ForeignKey("User")]
    public string Username { get; set; }
    public User User { get; set; }
    [ForeignKey("Spot")]
    public Guid SpotId { get; set; }
    public Spot Spot { get; set; }
    public InterestEnum InterestEnum { get; set; }

    public Interest()
    {
    }

    private Interest(InterestEnum interestEnum)
    {
        InterestEnum = interestEnum;
    }
    
    public static Interest Create(InterestEnum interestEnum)
    {
        return new Interest(interestEnum);
    }
}