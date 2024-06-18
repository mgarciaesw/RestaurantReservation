﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestaurantManagement.Domain.Repositories;
using RestaurantManagement.Infrastructure.Repository;

namespace RestaurantManagement.Infrastructure
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddInMemoryInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //string sqlDatabaseConnectionString = configuration.GetConnectionString("SqlDatabaseConnectionString") ?? throw new ArgumentNullException(nameof(configuration));
            string inMemoryDatabaseName = configuration["InMemoryDatabaseName"] ?? throw new ArgumentNullException(nameof(configuration));

            services.AddDbContext<ApplicationDBContext>(options => options.UseInMemoryDatabase(inMemoryDatabaseName));

            services.AddScoped<IRestaurantRepository, InMemoryRestaurantRepository>();

            return services;
        }

        public static IServiceCollection AddSqlServerInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            string sqlServerDatabaseName = configuration.GetConnectionString("SqlServerDatabaseName");

            services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(sqlServerDatabaseName));

            services.AddScoped<IRestaurantRepository, SqlServerRestaurantRepository>();

            return services;
        }
    }
}
