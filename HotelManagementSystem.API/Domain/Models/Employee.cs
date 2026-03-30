using HotelManagementSystem.API.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace HotelManagementSystem.API.Domain.Models
{
    public class Employee : BaseEntity
    {
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public Guid HotelId { get; set; }
        public Hotel Hotel { get; set; } = null;
        public Guid RoleId { get; set; }
        public Role Role { get; set; }
        public List<Room> Rooms { get; set; } = new List<Room>();
    }
}
