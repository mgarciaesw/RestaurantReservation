namespace ReservationManagement.Application.Request
{
    public class UpdateReservationRequest
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int NumberOfPeople { get; set; }
        public int CustomerId { get; set; }
        public int RestaurantId { get; set; }
    }
}
