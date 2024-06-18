using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportSpot.Application.Services.ImageService;

namespace SportSpot.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ImageController(IImageService imageService) : ControllerBase
{
    private readonly IImageService _imageService = imageService;

    [HttpPost("Add")]
    public Guid AddImage(string imageLink)
    {
        return _imageService.CreateImage(imageLink);
    }
}