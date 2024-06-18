using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ReservationManagement.Domain.Repositories;
using ReservationManagement.Infrastructure.Repository;

namespace ReservationManagement.Infrastructure
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            /*string inMemoryDatabaseName = configuration["InMemoryDatabaseName"] ?? throw new ArgumentNullException(nameof(configuration));*/

            services.AddDbContext<ApplicationDBContext>((serviceProvider, dbContextOptionsBuilder) =>
            {
                dbContextOptionsBuilder.UseNpgsql(configuration.GetConnectionString("WebApiDatabase"));

                dbContextOptionsBuilder.EnableDetailedErrors(true);
                dbContextOptionsBuilder.EnableSensitiveDataLogging(true);
            });

            services.AddScoped<IReservationRepository, EfReservationRepository>();

            return services;
        }
    }
}
