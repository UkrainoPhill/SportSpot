using SportSpot.Logic.Models;

namespace SporSpot.Infrastructure.JwtProvider;

public interface IJwtProvider
{
    string GenerateToken(User user);
}