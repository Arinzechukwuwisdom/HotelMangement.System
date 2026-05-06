using HotelManagementSystem.API.Domain.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagementSystem.API.Domain.Models
{
    public class Room
    {
        public Guid Id { get; set; }
        public required int RoomNo { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public required decimal Price { get; set; }
        public required RoomStatus RoomStatus { get; set; }
        //public Guid RoomTypeId { get; set; }
        public string RoomType { get; set; }
        public bool IsAvailable => RoomStatus == RoomStatus.Available;
        //public Guid HotelId { get; set; }
        //public Hotel Hotel { get; set; }
        public List<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
