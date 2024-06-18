using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportSpot.Logic.Models;

namespace SportSpot.Persistence.Configurations;

public class SpotConfiguration : IEntityTypeConfiguration<Spot>
{
    public void Configure(EntityTypeBuilder<Spot> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(s => s.Comments)
            .WithOne(c => c.Spot);
        builder.HasMany(s => s.Interests)
            .WithOne(i => i.Spot);
        builder.HasMany(s => s.Images)
            .WithOne();
    }
}