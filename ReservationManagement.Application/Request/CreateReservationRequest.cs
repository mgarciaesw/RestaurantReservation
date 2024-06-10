namespace ReservationManagement.Application.Request
{
    public class CreateReservationRequest
    {
        public DateTime Date { get; set; }
        public int NumberOfPeople { get; set; }
        public int CustomerId { get; set; }
        public int RestaurantId { get; set; }
    }
}
