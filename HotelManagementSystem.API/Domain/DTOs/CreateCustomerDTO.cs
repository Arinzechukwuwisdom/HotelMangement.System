namespace HotelManagementSystem.API.Domain.DTOs
{
    public class CreateCustomerDTO
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
    }
}
