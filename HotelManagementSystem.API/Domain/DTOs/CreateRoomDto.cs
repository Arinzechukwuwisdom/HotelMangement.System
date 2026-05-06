using HotelManagementSystem.API.Domain.Enum;

namespace HotelManagementSystem.API.Domain.DTOs
{
    public class CreateRoomDto
    {
        public int RoomNo { get; set; }
        public string RoomType { get; set; } // e.g. Single, Double
        public decimal PricePerNight { get; set; }
        public RoomStatus RoomStatus { get; set; }

    }
}
