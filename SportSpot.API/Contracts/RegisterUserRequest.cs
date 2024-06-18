using System.ComponentModel.DataAnnotations;
using SportSpot.Logic;
using SportSpot.Logic.Models;

namespace SportSpot.API.Contracts;

public record RegisterUserRequest([Required] string username, [Required] string password, [Required] string email,
    [Required] string name, [Required] string surname, [Required] string gender,
    [Required] DateOnly birthDate, List<string> interests,
    string imageLink);