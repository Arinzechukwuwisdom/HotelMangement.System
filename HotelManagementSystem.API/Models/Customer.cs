using HotelManagementSystem.API.Entities;

namespace HotelManagementSystem.API.Models
{
    public class Customer:BaseEntity
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
