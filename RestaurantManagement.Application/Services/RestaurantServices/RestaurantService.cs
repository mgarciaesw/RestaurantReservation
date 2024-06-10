using RestaurantManagement.Domain.Entities.Restaurants;
using RestaurantManagement.Domain.Repositories;

namespace RestaurantManagement.Application.Services.RestaurantServices
{
    public sealed class RestaurantService(IRestaurantRepository restaurantRepository)
    {
        public async Task<int> CreateRestaurantAsync(NewRestaurantRequest request)
        {
            // Create a new restaurant entity
            var restaurant = new Restaurant
            {
                Name = request.Name,
                MaxNumberOfSeats = request.MaxNumberOfSeats
            };

            // Add the restaurant to the repository
            return await restaurantRepository.AddAndSaveAsync(restaurant);
        }

        public async Task DeleteRestaurantAsync(int id)
        {
            // Delete the restaurant from the repository
            await restaurantRepository.DeleteByIdAsync(id);
        }

        public async Task<Restaurant?> GetRestaurantByIdAsync(int id)
        {
            // Get the restaurant from the repository
            return await restaurantRepository.GetByIdAsync(id);
        }
    }
}
