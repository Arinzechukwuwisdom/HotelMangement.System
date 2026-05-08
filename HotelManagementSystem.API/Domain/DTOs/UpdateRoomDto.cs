namespace HotelManagementSystem.API.Domain.DTOs
{
    public class UpdateRoomDto
    {
        public int RoomNo { get; set; }
        public string RoomType { get; set; }
        public decimal Price { get; set; }
        //public bool IsAvailable { get; set; }
    }
}
