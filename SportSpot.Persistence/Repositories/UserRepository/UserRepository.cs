using Microsoft.EntityFrameworkCore;
using SportSpot.Logic.Models;

namespace SportSpot.Persistence.Repositories.UserRepository;

public class UserRepository(SportSpotDbContext context) : IUserRepository
{
    public User AddUser(User user)
    {
        context.Users.Add(user);
        context.SaveChanges();
        return user;
    }
    public User GetUserByEmailOrUsername(string emailOrUsername)
    {
        var user = context.Users.SingleOrDefault(c => c.Email == emailOrUsername || c.Username == emailOrUsername);
        return user;
    }
}