using RestaurantReservation.Core.Domain.Abstractions;

namespace ReservationManagement.Domain.Entities.Reservations
{
    public class Reservation : Entity
    {
        private Reservation(
            string date,
            int numberOfPeople,
            int customerId,
            int restaurantId)
        {
            Date = date;
            NumberOfPeople = numberOfPeople;
            CustomerId = customerId;
            RestaurantId = restaurantId;
        }

        public string Date { get; private set; }
        public int NumberOfPeople { get; private set; }
        public int CustomerId { get; private set; }
        public int RestaurantId { get; private set; }

        public static Reservation Create(
            string date,
            int numberOfPeople,
            int customerId,
            int restaurantId
            // inject customer client interface
            // inject restaurant client interface
            // inject repository interface
            )
        {
            // (++ client interfaces could be wrapped with cache decorator)

            // get customer from client interface     -> exception if not found

            // get restaurant from client interface   -> exception if not found

            // get reservations of restaurant for the given date

            // calculate reservations + numberOfPeople

            // if sum is greater than capacity        -> exception

            return new Reservation(
                date,
                numberOfPeople,
                customerId,
                restaurantId
            );
        }
    }
}
