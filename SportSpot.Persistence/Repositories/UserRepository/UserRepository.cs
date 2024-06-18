using Microsoft.EntityFrameworkCore;
using SportSpot.Logic.Models;

namespace SportSpot.Persistence.Repositories.UserRepository;

public class UserRepository(SportSpotDbContext context) : IUserRepository
{
    private readonly SportSpotDbContext _context = context;

    public User AddUser(User user)
    {
        context.Users.Add(user);
        context.SaveChanges();
        return user;
    }
    public User GetUserByEmailOrUsername(string emailOrUsername)
    {
        var user = _context.Users.SingleOrDefault(c => c.Email == emailOrUsername || c.Username == emailOrUsername);
        return user;
    }
}