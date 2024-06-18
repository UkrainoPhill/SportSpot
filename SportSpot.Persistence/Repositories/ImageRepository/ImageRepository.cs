using SportSpot.Logic.Models;

namespace SportSpot.Persistence.Repositories.ImageRepository;

public class ImageRepository(SportSpotDbContext context) : IImageRepository
{
    public Image FindImageByImageId(Guid imageId)
    {
        var image = context.Images.First(i => i.Id == imageId);
        return image;
    }
    
    public Image AddImage(string imageLink)
    {
        var image = Image.Create(imageLink);
        context.Images.Add(image);
        context.SaveChanges();
        return image;
    }
}