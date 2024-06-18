using RestaurantManagement.Domain.Entities.Restaurants;
using RestaurantManagement.Domain.Repositories;

namespace RestaurantManagement.Infrastructure.Repository
{
    public class SqlServerRestaurantRepository : IRestaurantRepository
    {
        private readonly ApplicationDBContext _context;

        public SqlServerRestaurantRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Restaurant?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Restaurants.FindAsync(id);
        }

        public async Task<int> AddAndSaveAsync(Restaurant item, CancellationToken cancellationToken)
        {
            await _context.Restaurants.AddAsync(item);
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteByIdAsync(int id, CancellationToken cancellationToken)
        {
            var customer = await _context.Restaurants.FindAsync(id);
            if (customer != null)
            {
                _context.Restaurants.Remove(customer);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
