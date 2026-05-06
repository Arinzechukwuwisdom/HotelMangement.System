using HotelManagementSystem.API.Domain.DTOs;
using HotelManagementSystem.API.Utility;

namespace HotelManagementSystem.API.Data_Access.Interfaces
{
    public interface ICustomer
    {
        Task<ResponseDetails<CustomerResponseDto>> CreateCustomerAsync(CreateCustomerDto customerDetails);
        Task<ResponseDetails<CustomerResponseDto>> UpdateCustomerAsync(Guid id, UpdateCustomerDto updateCustomer);
        Task<ResponseDetails<CustomerResponseDto>> GetCustomerByIdAsync(Guid id);
        Task<ResponseDetails<CustomerResponseDto>> DeleteCustomer(Guid id);
    }   
}
