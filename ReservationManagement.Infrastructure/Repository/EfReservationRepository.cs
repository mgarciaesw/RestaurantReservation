using Microsoft.EntityFrameworkCore;
using ReservationManagement.Domain.Entities.Reservations;
using ReservationManagement.Domain.Repositories;

namespace ReservationManagement.Infrastructure.Repository
{
    public class EfReservationRepository(ApplicationDBContext context) : IReservationRepository
    {
        public Task<Reservation?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return context.Reservations.FirstOrDefaultAsync(reservation => reservation.Id == id, cancellationToken);
        }

        public async Task<int> AddAndSaveAsync(Reservation item, CancellationToken cancellationToken)
        {
            context.Reservations.Add(item);

            await context.SaveChangesAsync(cancellationToken);

            return item.Id;
        }

        public Task DeleteByIdAsync(int id, CancellationToken cancellationToken)
        {
            var reservation = context.Reservations.FirstOrDefault(reservation => reservation.Id == id);
            if (reservation is not null)
            {
                context.Reservations.Remove(reservation);
                return context.SaveChangesAsync(cancellationToken);
                
            }

            return Task.FromException(new InvalidOperationException("Reservation not found"));
        }
    }
}
