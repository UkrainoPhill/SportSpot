using Microsoft.EntityFrameworkCore;
using SportSpot.Logic.Models;

namespace SportSpot.Persistence;

public class SportSpotDbContext(DbContextOptions<SportSpotDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Spot> Spots { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Image> Images { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new Configurations.UserConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.SpotConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.CommentConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.ImageConfiguration());
    }
}