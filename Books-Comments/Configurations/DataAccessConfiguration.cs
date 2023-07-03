using Books_Comments.DataAccess.DbContexts;
using Books_Comments.DataAccess.Interfaces;
using Books_Comments.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
namespace Books_Comments.Configurations;

public static class DataAccessConfiguration
{
    public static void AddDataAccess(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("DatabaseConnection");
        services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
