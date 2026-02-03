using HotelManagementSystem.API.Entities;

namespace HotelManagementSystem.API.Models
{
    public class Customer:BaseEntity
    {
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
