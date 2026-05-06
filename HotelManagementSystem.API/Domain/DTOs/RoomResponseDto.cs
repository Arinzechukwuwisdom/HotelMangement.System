using HotelManagementSystem.API.Domain.Enum;

namespace HotelManagementSystem.API.Domain.DTOs
{
    public class RoomResponseDto
    {
        public Guid Id { get; set; }
        public int RoomNo { get; set; }
        public string RoomType { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public RoomStatus RoomStatus { get; set; }
    }
}
