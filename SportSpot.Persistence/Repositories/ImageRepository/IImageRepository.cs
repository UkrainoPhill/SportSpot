using SportSpot.Logic.Models;

namespace SportSpot.Persistence.Repositories.ImageRepository;

public interface IImageRepository
{
    Image FindImageByImageId( Guid imageId);
    Image AddImage(Image image);
}