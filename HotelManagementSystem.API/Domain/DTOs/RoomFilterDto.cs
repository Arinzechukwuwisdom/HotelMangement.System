using HotelManagementSystem.API.Domain.Enum;

namespace HotelManagementSystem.API.Domain.DTOs
{
    public class RoomFilterDto
    {
        public string? RoomType { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public bool? IsAvailable { get; set; }

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
