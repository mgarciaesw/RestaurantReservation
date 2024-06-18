using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace RestaurantManagement.Infrastructure.Extensions
{
    public static class MigrationsExtension
    {
        public static IApplicationBuilder ApplyMigrations(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDBContext>();
                dbContext.Database.Migrate();
            }

            return app;
        }
    }
}
