using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportSpot.Logic.Models;

namespace SportSpot.Persistence.Configurations;

public class ImageConfiguration : IEntityTypeConfiguration<Image>
{
    public void Configure(EntityTypeBuilder<Image> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(i => i.User)
            .WithOne(u => u.Image)
            .HasForeignKey<Image>(i => i.Username);
        builder.HasOne(i => i.Spot)
            .WithMany(s => s.Images)
            .HasForeignKey(i => i.SpotId);
        builder.HasOne(i => i.Comment)
            .WithMany(c => c.Images);
    }
}