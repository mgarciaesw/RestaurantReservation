using RestaurantManagement.Application.Services.RestaurantServices;

namespace RestaurantManagement.API.RouteHandlerExtensions
{
    public static class APIRouteHandler
    {
        public static void AddMinimalAPIRouteHandlerMappings(this WebApplication app)
        {
            app.MapGet("/restaurant/{restaurantId}", (RestaurantService service, int restaurantId) =>
                {
                    return service.GetRestaurantByIdAsync(restaurantId);
                })
                .WithName("GetRestaurantById")
                .WithOpenApi();

            app.MapPost("/restaurant", (RestaurantService service, NewRestaurantRequest request) =>
                {
                    return service.CreateRestaurantAsync(request);
                })
                .WithName("CreateRestaurant")
                .WithOpenApi();

            app.MapDelete("/restaurant/{restaurantId}", (RestaurantService service, int restaurantId) =>
                {
                    return service.DeleteRestaurantAsync(restaurantId);
                })
                .WithName("DeleteRestaurant")
                .WithOpenApi();
        }
    }
}
