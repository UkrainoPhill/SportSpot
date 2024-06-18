using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SportSpot.API.Contracts;
using SportSpot.Application.Services.UserService;

namespace SportSpot.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IUserService userService) : ControllerBase
{

    /// <summary>
    /// Registers a new user
    /// </summary>
    /// <param name="registerUserRequest">
    /// Username: string max value 20 min value 2 &#xA;
    /// Email: string max value 50 min value 5 &#xA;
    /// Name: string max value 50 min value 2 &#xA;
    /// Surname: string max value 50 min value 2 &#xA;
    /// Date: Date, format: yyyy - mm - dd, min value today - 100 years, max value today &#xA;
    /// Gender: Male or Female &#xA;
    /// ImageLink: Optional &#xA;
    /// Interests: List of strings, Optional &#xA;
    /// </param>>
    /// <returns>Ok</returns>
    [HttpPost("Register")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public ActionResult AddUser([FromBody] RegisterUserRequest registerUserRequest)
    {
        try
        {
            userService.AddUser(registerUserRequest.username, registerUserRequest.password, 
                registerUserRequest.email, registerUserRequest.name, registerUserRequest.surname, 
                registerUserRequest.gender, registerUserRequest.birthDate, 
                registerUserRequest.imageLink, registerUserRequest.interests);
        }
        catch (ArgumentException e)
        {
            if (e.Message == "User already exists")
            {
                return Conflict(e.Message);
            }
            return BadRequest(e.Message);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message); 
        } 
        return NoContent(); 
    }
    /// <summary>
    /// Login user using JWT token and Cookies
    /// </summary>
    /// <param name="loginUserRequest">
    /// EmailOrUsername: string &#xA;
    /// Password: string &#xA;
    /// </param>
    /// <returns></returns>
    [HttpPost("Login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<string> Login([FromBody] LoginUserRequest loginUserRequest)
    {
        try
        {
            var token = userService.Login(loginUserRequest.emailOrUsername, loginUserRequest.password);
            HttpContext.Response.Cookies.Append("access_token", token);
            return Ok(token);
        }
        catch (ArgumentException e)
        {
            return BadRequest(e.Message);
        }
    }
}