using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportSpot.Logic.Models;

namespace SportSpot.Persistence.Configurations;

public class InterestConfiguration : IEntityTypeConfiguration<Interest>
{
    public void Configure(EntityTypeBuilder<Interest> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(i => i.User)
            .WithMany(u => u.Interests)
            .HasForeignKey(i => i.Username);
        builder.HasOne(i => i.Spot)
            .WithMany(s => s.Interests)
            .HasForeignKey(i => i.SpotId);
    }
}