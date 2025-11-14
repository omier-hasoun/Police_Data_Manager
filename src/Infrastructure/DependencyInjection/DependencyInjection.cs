using Microsoft.Extensions.DependencyInjection;
using Infrastructure.UserService;
using Microsoft.AspNetCore.Identity;
using Infrastructure.Data;


namespace Infrastructure.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<ICurrentUserService, CurrentUserService>();

        services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

        return services;
    }

}
