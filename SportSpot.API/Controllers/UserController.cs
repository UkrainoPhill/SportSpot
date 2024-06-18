using Microsoft.AspNetCore.Mvc;
using SportSpot.API.Contracts;
using SportSpot.Application.Services.UserService;

namespace SportSpot.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IUserService userService) : ControllerBase
{
    [HttpPost("Register")]
    public OkResult AddUser([FromBody] RegisterUserRequest registerUserRequest)
    {
        userService.AddUser(registerUserRequest.username, registerUserRequest.password, registerUserRequest.email, registerUserRequest.name, registerUserRequest.surname, registerUserRequest.gender, registerUserRequest.birthDate, registerUserRequest.imageLink);
        return Ok();
    }
    
    [HttpPost("Login")]
    public OkObjectResult Login([FromBody] LoginUserRequest loginUserRequest)
    { 
        var token = userService.Login(loginUserRequest.emailOrUsername, loginUserRequest.password);
        HttpContext.Response.Cookies.Append("access_token", token);
        return Ok(token);
    }
}