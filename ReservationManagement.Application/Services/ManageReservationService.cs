using ReservationManagement.Application.Request;
using ReservationManagement.Domain.Repositories;
using ReservationManagement.Domain.Entities.Reservations;

namespace ReservationManagement.Application.Services
{
    public class ManageReservationService
    {
        private readonly IReservationRepository _repository;

        public ManageReservationService(IReservationRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> CreateReservationAsync(CreateReservationRequest request)
        {
            // Create a new customer entity
            var reservation = Reservation.Create(
                request.Date.ToString(),
                request.NumberOfPeople,
                request.CustomerId,
                request.RestaurantId);

            // Add the customer to the repository
            return await _repository.AddAndSaveAsync(reservation);
        }

        public async Task DeleteReservationAsync(int id)
        {
            // Delete the customer from the repository
            await _repository.DeleteByIdAsync(id);
        }

        public async Task<Reservation?> GetReservationByIdAsync(int id)
        {
            // Get the customer from the repository
            return await _repository.GetByIdAsync(id);
        }
    }
}
