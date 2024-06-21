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

    public User GetUserByEmail(string email)
    {
        var user = context.Users.SingleOrDefault(c => c.Email == email);
        return user;
    }
    
    public User GetUserByUsername(string username)
    {
        var user = context.Users.SingleOrDefault(c => c.Username == username);
        return user;
    }
}