using HotelManagementSystem.API.Domain.DTOs;
using HotelManagementSystem.API.Utility;

namespace HotelManagementSystem.API.Data_Access.Interfaces
{
    public interface ICustomerRepository
    {
        Task<ResponseDetails<CustomerResponseDTO>> CreateCustomer(CreateCustomerDTO customerDetails);
        Task<ResponseDetails<CustomerResponseDTO>> UpdateCustomer(Guid id, UpdateCustomerDTO updateCustomer);
        Task<ResponseDetails<CustomerResponseDTO>> GetCustomerById(Guid id);
        Task<ResponseDetails<CustomerResponseDTO>> DeleteCustomer(Guid id);
    }
}
