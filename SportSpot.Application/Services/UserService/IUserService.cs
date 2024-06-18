using SportSpot.Logic.Models;

namespace SportSpot.Application.Services.UserService;

public interface IUserService
{
    void AddUser(string username, string password, string email, string name, string surname, string stringGender,
        DateOnly birthDate, string imageLink);
    string Login(string emailOrUsername, string password);
}