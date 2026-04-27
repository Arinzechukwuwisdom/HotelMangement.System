namespace HotelManagementSystem.API.Domain.DTOs
{
    public class CustomerResponseDTO
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
    }
}
