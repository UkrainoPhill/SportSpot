using System.ComponentModel.DataAnnotations;

namespace SportSpot.API.Contracts;

public record LoginUserRequest([Required]string emailOrUsername, [Required] string password);