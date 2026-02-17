using HotelManagementSystem.API.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagementSystem.API.Models
{
    public class Room
    {
        [Key]
        public Guid Id { get; set; }
        public int RoomNo { get; set; }
        public decimal Price { get; set; }
        public RoomStatus Status { get; set; }
        public Guid RoomTypeId { get; set; }
        public RoomType Type { get; set; }       
        public bool IsAvailable => Status == RoomStatus.Available;
        public Guid HotelId { get; set; }
        public Hotel Hotel { get; set; }
        public List<Booking> Bookings { get; set; }=new List<Booking>();
    }
}
