namespace HotelManagementSystem.API.Domain.DTOs
{
    public class GetHotelDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
    }
}
