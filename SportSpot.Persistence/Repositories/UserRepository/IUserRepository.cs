using SportSpot.Logic.Models;

namespace SportSpot.Persistence.Repositories.UserRepository;

public interface IUserRepository
{
    User AddUser(User user);
    User GetUserByEmailOrUsername(string emailOrUsername);
}