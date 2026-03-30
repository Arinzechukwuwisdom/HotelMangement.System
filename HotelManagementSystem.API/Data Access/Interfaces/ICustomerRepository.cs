using HotelManagementSystem.API.Domain.DTOs;

namespace HotelManagementSystem.API.Data_Access.Interfaces
{
    public interface ICustomer
    {
        Task<ResponseCustomerDTO> CreateCustomer(CreateCustomerDTO customerDetails);
        Task<ResponseCustomerDTO> UpdateHotel(Guid id, UpdateHotelDTO updateHotel);
        Task<ResponseCustomerDTO> GetHotelById(Guid id);
        Task<ResponseCustomerDTO> DeleteHotel(Guid id);
    }
}
