using SportSpot.Logic;
using SportSpot.Logic.Models;

namespace SportSpot.Application.Services.UserService;

public interface IUserService
{
    void AddUser(string username, string password, string email, string name, string surname, string stringGender,
        DateOnly birthDate, string imageLink, List<string> interests);
    string Login(string emailOrUsername, string password);
}