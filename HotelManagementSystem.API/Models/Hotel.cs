using HotelManagementSystem.API.Entities;
using System.Collections;

namespace HotelManagementSystem.API.Models
{
    public class Hotel : BaseEntity
    {
        public string City { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public decimal Rating { get; set; }
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
        public ICollection<Room> Rooms { get; set; } = new List<Room>();
        //public Guid RoleId {  get; set; }
        //public Role Role { get; set; }
    }
}
