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
        public readonly ICustomer _customerRepository;
        public CustomerController(ICustomer customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CreateCustomerDto customerDetails)
        {
            try
            {
                var req = await _customerRepository.CreateCustomerAsync(customerDetails);
                if (!req.IsSuccess)
                {
                    return BadRequest(req);
                }
                return Ok(req);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
