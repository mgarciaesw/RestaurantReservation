﻿using Microsoft.Extensions.DependencyInjection;
using RestaurantManagement.Application.Services.RestaurantServices;

namespace RestaurantManagement.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<RestaurantService>();

            return services;
        }
    }
}
