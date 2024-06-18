using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SporSpot.Infrastructure.JwtProvider;
using SporSpot.Infrastructure.JWTProvider;
using SporSpot.Infrastructure.PasswordHasher;
using SportSpot.Application.Services.ImageService;
using SportSpot.Application.Services.UserService;
using SportSpot.Persistence;
using SportSpot.Persistence.Repositories.ImageRepository;
using SportSpot.Persistence.Repositories.UserRepository;

namespace SportSpot.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(nameof(JwtOptions)));
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddScoped<IImageRepository, ImageRepository>();
        builder.Services.AddScoped<IImageService, ImageService>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
        builder.Services.AddScoped<IJwtProvider, JwtProvider>();
        
        builder.Services.AddDbContext<SportSpotDbContext>(options =>
        {
            options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(SportSpotDbContext)) + ";Include Error Detail=True");
        });
        var app = builder.Build();
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.UseAuthentication();
        app.MapControllers();
        app.Run();
    }
}