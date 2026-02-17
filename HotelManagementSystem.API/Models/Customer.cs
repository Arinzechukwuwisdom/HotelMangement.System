using HotelManagementSystem.API.Entities;

namespace HotelManagementSystem.API.Models
{
    public class Customer:BaseEntity
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; } 
        public string Address { get; set; }
        public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
