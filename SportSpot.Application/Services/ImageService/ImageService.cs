using System.Transactions;
using SportSpot.Persistence.Repositories.ImageRepository;

namespace SportSpot.Application.Services.ImageService;

public class ImageService(IImageRepository imageRepository) : IImageService
{
    private readonly IImageRepository _imageRepository = imageRepository;

    public Guid CreateImage(string imageLink)
    {
        using var transaction = new TransactionScope();
        var image = _imageRepository.AddImage(imageLink);
        transaction.Complete();
        return image.Id;

    }
}