using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace CleanApiRest.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<CleanApiRestDbContext>(opt => 
            opt.UseSqlServer(configuration.GetConnectionString("ConnectionString")));
            return services;
        }
    }
}
