using HotelManagementSystem.API.Domain.Entities;

namespace HotelManagementSystem.API.Domain.Models
{
    public class Customer : BaseEntity
    {
        public required string EmailAddress { get; set; }
        public required string Password { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Address { get; set; }
        public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
