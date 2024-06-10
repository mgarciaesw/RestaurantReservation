using RestaurantManagement.Application.Services.RestaurantServices;

namespace RestaurantManagement.API.RouteHandlerExtensions
{
    public static class APIRouteHandler
    {
        public static void AddMinimalAPIRouteHandlerMappings(this WebApplication app)
        {
            app.MapGet("/restaurant", (RestaurantService service, int customerId) =>
                {
                    return service.GetRestaurantByIdAsync(customerId);
                })
                .WithName("GetRestaurantById")
                .WithOpenApi();

            app.MapPost("/restaurant", (RestaurantService service, NewRestaurantRequest request) =>
                {
                    return service.CreateRestaurantAsync(request);
                })
                .WithName("CreateRestaurant")
                .WithOpenApi();

            app.MapDelete("/restaurant", (RestaurantService service, int customerId) =>
                {
                    return service.DeleteRestaurantAsync(customerId);
                })
                .WithName("DeleteRestaurant")
                .WithOpenApi();
        }
    }
}
