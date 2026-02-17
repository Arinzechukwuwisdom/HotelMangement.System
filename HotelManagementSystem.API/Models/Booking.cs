namespace HotelManagementSystem.API.Models
{
    public class Booking
    {
        public Guid Id { get; set; }

        public Guid RoomId { get; set; }
        public Room Room { get; set; }

        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }

        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
    }

}
