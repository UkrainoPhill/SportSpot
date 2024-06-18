using SportSpot.Logic.Models;

namespace SportSpot.Persistence.Repositories.ImageRepository;

public interface IImageRepository
{
    public Image FindImageByImageId( Guid imageId);
    public Image AddImage(string imageLink);
}