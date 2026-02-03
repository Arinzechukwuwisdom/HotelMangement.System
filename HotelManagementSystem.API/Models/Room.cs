namespace HotelManagementSystem.API.Models
{
    public class Room
    {
        public Guid Id { get; set; }
        public int RoomNo { get; set; }
        public string RoomType { get; set; }
        public bool IsAvalaible { get; set; }
    }
}
