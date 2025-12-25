using Application.IServices;
using Application.Services;
using Domain.Entity;
using Domain.IRepository;
using Infrastructure.Data;
using Infrastructure.Repository;
using Infrastructure.UserState;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Web.Api.Configurations;

public static class DbConfiguration
{
    public static IServiceCollection AddDbConfiguration(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(opt =>
            opt.UseSqlServer(configuration.GetConnectionString("ConnectionString")));

        services.AddDataProtection();

        // Register Identity with proper role store
        services
            .AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.User.RequireUniqueEmail = true;
                options.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
            })
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();


        services.AddCors(opt => opt.AddPolicy("All", corsPolicyBuilder =>
        {
            corsPolicyBuilder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin();
        }));

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUnityOfWork, UnityOfWork>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IJwtService, JwtService>();
        services.AddScoped<ITasksService, TasksService>();
        services.AddScoped<ITasksRepository, TasksRepository>();
        services.AddScoped<IUserState, UserState>();

        return services;
    }
}