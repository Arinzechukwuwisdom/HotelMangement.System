using HotelManagementSystem.API.Data_Access.Interfaces;
using HotelManagementSystem.API.Data_Access.Repository;
using HotelManagementSystem.API.Domain.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public readonly ICustomerRepository _customerRepository;
        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CreateCustomerDTO customerDetails)
        {
            var customer= await _customerRepository.CreateCustomerAsync(customerDetails);
            return Ok(customer);
        }

    }
}
