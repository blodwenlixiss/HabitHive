using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Web.Api.Configurations;

public static class DbConfiguration
{
    public static IServiceCollection AddDbConfiguration(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(opt =>
            opt.UseSqlServer(configuration.GetConnectionString("ConnectionString")));

        return services;
    }
}