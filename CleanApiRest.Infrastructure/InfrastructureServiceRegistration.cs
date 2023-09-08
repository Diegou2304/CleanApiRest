using CleanApiRest.Application.Contracts;
using CleanApiRest.Infrastructure.Persistence;
using CleanApiRest.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace CleanApiRest.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
           
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ICarStoreRepository, CarStoreRepository>();
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddDbContext<CleanApiRestDbContext>(opt => 
            opt.UseSqlServer(configuration.GetConnectionString("ConnectionString")));
            return services;
        }
    }
}
