using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportSpot.Logic.Models;

namespace SportSpot.Persistence.Configurations;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(c => c.User)
            .WithMany(u => u.Comments)
            .HasForeignKey(c => c.Username);
        builder.HasOne(c => c.Spot)
            .WithMany(s => s.Comments)
            .HasForeignKey(c => c.SpotId);
        builder.HasMany(c => c.Images).WithOne(i => i.Comment);
    }
}