using Microsoft.EntityFrameworkCore;
using UserManagement.Domain.Entities.Customers;
using UserManagement.Domain.Repositories;

namespace UserManagement.Infrastructure.Repository
{
    public class EfCustomerRepository(ApplicationDBContext context) : ICustomerRepository
    {
        public Task<Customer?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return context.Customers.FirstOrDefaultAsync(customer => customer.Id == id);
        }

        public async Task<int> AddAndSaveAsync(Customer item, CancellationToken cancellationToken)
        {
            context.Customers.Add(item);
            await context.SaveChangesAsync();
            return item.Id;
        }

        public Task DeleteByIdAsync(int id, CancellationToken cancellationToken)
        {
            var customer = context.Customers.FirstOrDefault(c => c.Id == id);
            if (customer is not null)
            {
                context.Customers.Remove(customer);
                return context.SaveChangesAsync();
            }

            return Task.FromException(new Exception());
        }
    }
}
