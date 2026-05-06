using HotelManagementSystem.API.Context;
using HotelManagementSystem.API.Data_Access.Interfaces;
using HotelManagementSystem.API.Domain.DTOs;
using HotelManagementSystem.API.Domain.Models;
using HotelManagementSystem.API.Utility;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.API.Data_Access.Repository
{
    public class CustomerRepository : ICustomer
    {

        public readonly HotelContext _context;
        ILogger<CustomerRepository> _logger;
        public CustomerRepository(HotelContext context, ILogger<CustomerRepository> logger)
        {
            _logger = logger;
            _context = context;
        }
        
        public async Task<ResponseDetails<CustomerResponseDto>> CreateCustomerAsync(CreateCustomerDto customerDetails)
        {
            try
            {
                var customerExists = await _context.Customers
                    .AnyAsync(x => x.EmailAddress == customerDetails.EmailAddress);

                if (customerExists)
                {
                    return new ResponseDetails<CustomerResponseDto>
                    {
                        IsSuccess = false,
                        Message = "Customer with this email already exists",
                        Data = null
                    };
                }

                var customer = new Customer
                {
                    FullName = customerDetails.FirstName + " " + customerDetails.LastName,
                    EmailAddress = customerDetails.EmailAddress,
                    City = customerDetails.City,
                    Country = customerDetails.Country,
                    PhoneNumber = customerDetails.PhoneNumber,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(customerDetails.Password)
                };

                await _context.Customers.AddAsync(customer);
                await _context.SaveChangesAsync();

                // 5. Map to response DTO
                var response = new CustomerResponseDto
                {
                    Id = customer.Id,
                    Address=customer.Address,
                    FullName = customer.FullName,
                };

                return new ResponseDetails<CustomerResponseDto>
                {
                    IsSuccess = true,
                    Message = "Customer created successfully",
                    Data = response
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating customer with email: {Email}", customerDetails.EmailAddress);

                return new ResponseDetails<CustomerResponseDto>
                {
                    IsSuccess = false,
                    Message = $"An error occurred: {ex.Message}",
                    Data = null
                };
            }
        }

        public async Task<ResponseDetails<CustomerResponseDto>> DeleteCustomer(Guid id)
        {
           try
            {
                var customer = await _context.Customers.FindAsync(id);
                if (customer == null)
                {
                    return new ResponseDetails<CustomerResponseDto>
                    {
                        IsSuccess = false,
                        Message="Customer not found",
                        Data = null
                    };
                }
                _context.Remove(customer);
                await _context.SaveChangesAsync();
                return new ResponseDetails<CustomerResponseDto>
                {
                    IsSuccess = true,
                    Message = "Customer Deleted Successfully"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting customer with id: {id}",id);

                return new ResponseDetails<CustomerResponseDto>
                {
                    IsSuccess = false,
                    Message = "An error occurred while deleting the customer"
                };
            }
        }

        public async Task<ResponseDetails<CustomerResponseDto>> GetCustomerByIdAsync(Guid id)
        {
            try
            {
                var customer = await _context.Customers.FindAsync(id);
                if (customer == null)
                {
                    return new ResponseDetails<CustomerResponseDto>
                    {
                        IsSuccess = false,
                        Data = null,
                        Message = "Customer not found"
                    };
                }
                return new ResponseDetails<CustomerResponseDto>
                {
                    IsSuccess = true,
                    Message = "Customer fetched Successfully"
                };
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, "Error occurred while finding customer with id: {id}", id);

                return new ResponseDetails<CustomerResponseDto>
                {
                    IsSuccess = false,
                    Message = "An error occurred while finding the customer"
                };
            }
        }

        public async Task<ResponseDetails<CustomerResponseDto>> UpdateCustomerAsync(Guid id, UpdateCustomerDto customerDetails)
        {
            try
            {
                var customer = await _context.Customers.FindAsync(id);
                if (customer == null)
                {
                    return new ResponseDetails<CustomerResponseDto>
                    {
                        IsSuccess = false,
                        Data = null,
                        Message = "Customer not found"
                    };
                }
               
                //await _context.AddAsync(customer);
                customer.FullName = customerDetails.Name ?? customer.FullName;

                customer.Country = customerDetails.Country ?? customer.Country;

                customer.City = customerDetails.City ?? customer.City;

                customer.EmailAddress = customerDetails.Email ?? customer.EmailAddress;

                if (!string.IsNullOrEmpty(customerDetails.Password))
                {
                    customer.PasswordHash = customerDetails.Password;
                }

                customer.PhoneNumber = customerDetails.PhoneNumber ?? customer.PhoneNumber;

                await _context.SaveChangesAsync();
                var customerResponseDTO = new CustomerResponseDto
                {
                    FullName = customer.FullName,
                    City = customer.City,
                    Country = customer.Country,
                    Address = customer.Address,
                };

                return new ResponseDetails<CustomerResponseDto>
                {
                    IsSuccess = true,
                    Data = customerResponseDTO,
                    Message = "Customer Updated Successfully"
                };
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, "Error occurred while updating customer with id: {id}", id);

                return new ResponseDetails<CustomerResponseDto>
                {
                    IsSuccess = false,
                    Message = "An error occurred while updating customer"
                };
            }

        }
    }
}
