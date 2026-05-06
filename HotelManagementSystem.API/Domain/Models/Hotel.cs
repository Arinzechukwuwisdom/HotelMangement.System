using HotelManagementSystem.API.Domain.Entities;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagementSystem.API.Domain.Models
{
    public class Hotel 
    {
        [Key]
        public Guid Id { get; set; }
        [Column(TypeName = "Nvarchar(30)")]
        public required string City { get; set; }
        [Column(TypeName = "Nvarchar(30)")]
        public required string Country { get; set; }
        [Column(TypeName = "Nvarchar(30)")]
        public required string Address { get; set; }
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
        public ICollection<Room> Rooms { get; set; } = new List<Room>();
    }
}
