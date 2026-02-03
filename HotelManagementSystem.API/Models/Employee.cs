using HotelManagementSystem.API.Entities;
using Microsoft.AspNetCore.Identity;

namespace HotelManagementSystem.API.Models
{
    public class Employee:BaseEntity
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public RoleManager 
    }
}
