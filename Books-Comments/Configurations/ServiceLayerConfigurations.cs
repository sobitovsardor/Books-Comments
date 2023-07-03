using Books_Comments.DataAccess.Interfaces;
using Books_Comments.DataAccess.Repositories;
using Books_Comments.Service.Interfaces.Accounts;
using Books_Comments.Service.Interfaces;
using Books_Comments.Service.Services.Accounts;
using Books_Comments.Service.Services.Common;
using Books_Comments.Service.Services.Products;
using Books_Comments.Service.Interfaces.Products;

namespace Books_Comments.Configurations;

public static class ServiceLayerConfigurations
{
    public static void AddService(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IIdentityService, IdentityService>();
    }
}
