namespace ReservationManagement.Domain.Entities.Reservations
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int NumberOfPeople { get; set; }
        public int CustomerId { get; set; }
        public int RestaurantId { get; set; }
    }
}
