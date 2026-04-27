using HotelManagementSystem.API.Domain.DTOs;
using HotelManagementSystem.API.Utility;

namespace HotelManagementSystem.API.Data_Access.Interfaces
{
    public interface ICustomerRepository
    {
        Task<ResponseDetails<CustomerResponseDTO>> CreateCustomerAsync(CreateCustomerDTO customerDetails);
        Task<ResponseDetails<CustomerResponseDTO>> UpdateCustomerAsync(Guid id, UpdateCustomerDTO updateCustomer);
        Task<ResponseDetails<CustomerResponseDTO>> GetCustomerByIdAsync(Guid id);
        Task<ResponseDetails<CustomerResponseDTO>> DeleteCustomer(Guid id);
    }   
}
