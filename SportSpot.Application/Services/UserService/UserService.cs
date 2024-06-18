using System.Transactions;
using SporSpot.Infrastructure.JwtProvider;
using SporSpot.Infrastructure.PasswordHasher;
using SportSpot.Logic.Models;
using SportSpot.Persistence.Repositories.ImageRepository;
using SportSpot.Persistence.Repositories.UserRepository;

namespace SportSpot.Application.Services.UserService;

public class UserService(IImageRepository imageRepository, IUserRepository userRepository, IPasswordHasher passwordHasher, IJwtProvider jwtProvider)
    : IUserService
{
    public void AddUser(string username, string password, string email, string name, string surname, string stringGender,
        DateOnly birthDate, string imageLink)
    {
        using var transaction = new TransactionScope();
        var image = string.IsNullOrEmpty(imageLink) ? imageRepository.AddImage("https://i.ibb.co/YdBKQfT/150-1503941-user-windows-10-user-icon-png-transparent-png.png") : imageRepository.AddImage(imageLink);
        bool gender = stringGender switch
        {
            "Male" => true,
            "Female" => false,
            _ => throw new ArgumentException("Not a valid gender")
        }; 
        var hashPassword = passwordHasher.HashPassword(password);
        var user = User.Create(username, hashPassword, email, name, surname, gender, birthDate);
        user.Image = image;
        userRepository.AddUser(user);
        transaction.Complete();
    }

    public string Login(string emailOrUsername, string password)
    {
        var user = userRepository.GetUserByEmailOrUsername(emailOrUsername);
        var isPasswordValid = passwordHasher.VerifyPassword(password, user.Password);
        if (isPasswordValid == false)
        {
            throw new ArgumentException("Invalid password");
        }
        var token = jwtProvider.GenerateToken(user);
        return token;
    }
}