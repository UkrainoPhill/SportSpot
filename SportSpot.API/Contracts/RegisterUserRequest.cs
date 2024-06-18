using System.ComponentModel.DataAnnotations;

namespace SportSpot.API.Contracts;

public record RegisterUserRequest([Required] string username, [Required] string password, [Required] string email,
    [Required] string name, [Required] string surname, [Required] string gender,[Required] DateOnly birthDate,
    string imageLink);