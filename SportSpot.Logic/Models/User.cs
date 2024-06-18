using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportSpot.Logic.Models;

public class User
{
    [Key]
    [Column("Username")]
    public string? Username { get;}
    [Column("Password")]
    public string? Password { get;}
    [Column("Email")]
    public string? Email { get;}
    [Column("Name")]
    public string? Name { get;}
    [Column("Surname")]
    public string? Surname { get;}
    [Column("Gender")]
    public bool Gender { get;}
    [Column("BirthDate")]
    public DateOnly BirthDate { get;}
    [Column("Description")]
    public string? Description { get; set; } 
    public Image Image { get; set; }
    public List<InterestEnum> Interests { get; set; }
    public List<Comment> Comments { get; set; }
    // TODO Friends and Blocked
    // public List<Friend> Friends { get; set; }
    // public List<Blocked> Blocked { get; set; }

    public User()
    {
    }
    private User(string username, string? password, string? email, string? name, string? surname, bool gender, DateOnly birthDate)
    {
        Username = username;
        Password = password;
        Email = email;
        Name = name;
        Surname = surname;
        Gender = gender;
        BirthDate = birthDate;
    }

    public static User Create(string username, string? password, string? email, string? name, string? surname,
        bool gender, DateOnly birthDate)
    {
        if (string.IsNullOrEmpty(username) || username.Length > 20 || username.Length < 2)
        {
            throw new ArgumentException("Username is invalid");
        }
        if (string.IsNullOrEmpty(email) || email.Length > 50 || email.Length < 5)
        {
            throw new ArgumentException("Email is invalid");
        }
        if (string.IsNullOrEmpty(name) || name.Length > 50 || name.Length < 2)
        {
            throw new ArgumentException("Name is invalid");
        }
        if (string.IsNullOrEmpty(surname) || surname.Length > 50 || surname.Length < 2)
        {
            throw new ArgumentException("Surname is invalid");
        }
        if (birthDate > DateOnly.FromDateTime(DateTime.Today) || birthDate < DateOnly.FromDateTime(DateTime.Today).AddYears(-100)){
            throw new ArgumentException("BirthDate is invalid");
        }

        return new User(username, password, email, name, surname, gender, birthDate);
    }
}