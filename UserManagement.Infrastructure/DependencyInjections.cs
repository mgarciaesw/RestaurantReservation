using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserManagement.Domain.Repositories;
using UserManagement.Infrastructure.Repository;

namespace UserManagement.Infrastructure
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            string sqlDatabaseConnectionString = configuration.GetConnectionString("SqlDatabaseConnectionString") ?? throw new ArgumentNullException(nameof(configuration));
            // string inMemoryDatabaseName = configuration["InMemoryDatabaseName"] ?? throw new ArgumentNullException(nameof(configuration));

            services.AddDbContext<ApplicationDBContext>((serviceProvider, dbContextOptionsBuilder) =>
            {
                dbContextOptionsBuilder.UseNpgsql(sqlDatabaseConnectionString);
                dbContextOptionsBuilder.EnableDetailedErrors(true);
                dbContextOptionsBuilder.EnableSensitiveDataLogging(true);
            });

            services.AddScoped<ICustomerRepository, EfCustomerRepository>();

            return services;
        }
    }
}
