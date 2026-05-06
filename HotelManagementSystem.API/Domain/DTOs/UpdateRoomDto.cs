namespace HotelManagementSystem.API.Domain.DTOs
{
    public class UpdateRoomDto
    {
        public string RoomNumber { get; set; }
        public string RoomType { get; set; }
        public decimal PricePerNight { get; set; }
        public bool IsAvailable { get; set; }
    }
}
