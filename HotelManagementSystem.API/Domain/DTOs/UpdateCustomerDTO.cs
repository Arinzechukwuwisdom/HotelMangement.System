namespace HotelManagementSystem.API.Domain.DTOs
{
    public class UpdateCustomerDTO
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string PhoneNumber { get; set; }

    }
}
