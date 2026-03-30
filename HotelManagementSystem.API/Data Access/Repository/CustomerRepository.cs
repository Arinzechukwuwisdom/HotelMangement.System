using HotelManagementSystem.API.Context;
using HotelManagementSystem.API.Data_Access.Interfaces;
using HotelManagementSystem.API.Domain.DTOs;
using HotelManagementSystem.API.Domain.Models;
using HotelManagementSystem.API.Repository;
using HotelManagementSystem.API.Utility;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.API.Data_Access.Repository
{
    public class CustomerRepository : ICustomerRepository
    {

        public readonly HotelContext _context;
        ILogger<CustomerRepository> _logger;
        public CustomerRepository(HotelContext context, ILogger<CustomerRepository> logger)
        {
            _logger = logger;
            _context = context;
        }
        
        public async Task<ResponseDetails<CustomerResponseDTO>> CreateCustomer(CreateCustomerDTO customerDetails)
        {
            try
            {
                var customerExists = await _context.Customers
                    .AnyAsync(x => x.EmailAddress == customerDetails.EmailAddress);

                if (customerExists)
                {
                    return new ResponseDetails<CustomerResponseDTO>
                    {
                        IsSuccess = false,
                        Message = "Customer with this email already exists",
                        Data = null
                    };
                }

                var customer = new Customer
                {
                    Address = customerDetails.Address,
                    Name = customerDetails.Name,
                    EmailAddress = customerDetails.EmailAddress,
                    PhoneNumber = customerDetails.PhoneNumber,
                    Password = BCrypt.Net.BCrypt.HashPassword(customerDetails.Password)
                };

                await _context.Customers.AddAsync(customer);
                await _context.SaveChangesAsync();

                // 5. Map to response DTO
                var response = new CustomerResponseDTO
                {
                    Id = customer.Id,
                    Address=customer.Address,
                    Name = customer.Name,
                };

                return new ResponseDetails<CustomerResponseDTO>
                {
                    IsSuccess = true,
                    Message = "Customer created successfully",
                    Data = response
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating customer with email: {Email}", customerDetails.EmailAddress);

                return new ResponseDetails<CustomerResponseDTO>
                {
                    IsSuccess = false,
                    Message = $"An error occurred: {ex.Message}",
                    Data = null
                };
            }
        }

        public async Task<ResponseDetails<CustomerResponseDTO>> DeleteCustomer(Guid id)
        {
           try
            {
                var customer = await _context.Customers.FindAsync(id);
                if (customer == null)
                {
                    return new ResponseDetails<CustomerResponseDTO>
                    {
                        IsSuccess = false,
                        Message="Customer not found"
                    };
                }
                _context.Remove(customer);
                await _context.SaveChangesAsync();
                return new ResponseDetails<CustomerResponseDTO>
                {
                    IsSuccess = true,
                    Message = "Customer Deleted Successfully"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting customer with id: {id}",id);

                return new ResponseDetails<CustomerResponseDTO>
                {
                    IsSuccess = false,
                    Message = "An error occurred while deleting the customer"
                };
            }
        }

        public Task<ResponseDetails<CustomerResponseDTO>> GetCustomerById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDetails<CustomerResponseDTO>> UpdateCustomer(Guid id, UpdateCustomerDTO updateCustomer)
        {
            throw new NotImplementedException();
        }
    }
}
