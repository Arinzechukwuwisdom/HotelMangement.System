using HotelManagementSystem.API.Entities;

namespace HotelManagementSystem.API.Models
{
    public class Hotel:BaseEntity
    {
        public string City { get; set; }
        public string Country { get; set; }

    }
}
