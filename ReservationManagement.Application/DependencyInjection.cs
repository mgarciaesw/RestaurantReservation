using Microsoft.Extensions.DependencyInjection;
using ReservationManagement.Application.Services;

namespace ReservationManagement.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {

            services.AddTransient<ManageReservationService>();

            return services;
        }
    }
}
