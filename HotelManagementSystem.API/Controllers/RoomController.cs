using HotelManagementSystem.API.Data_Access.Interfaces;
using HotelManagementSystem.API.Domain.DTOs;
using HotelManagementSystem.API.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        public readonly IRoom _roomRepository;
        public RoomController(IRoom roomRepository)
        {
            _roomRepository = roomRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomerAsync(CreateRoomDto dto)
        {
            try
            {
                var transaction = await _roomRepository.CreateRoomAsync(dto);
                if (!transaction.IsSuccess)
                {
                    return BadRequest(transaction);
                }
                return Ok(transaction);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetRoomsByFilterAsync(RoomFilterDto filter)
        {
            try
            {
                var req = await _roomRepository.GetRoomsByFilterAsync(filter);
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

        [HttpPatch]
        public async Task<IActionResult> UpdateRoomAsync (Guid id, UpdateRoomDto dto)
        {
            try
            {
                var req = await _roomRepository.UpdateRoomAsync(id, dto);
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

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            try
            {
                var req = await _roomRepository.DeleteAsync(id);
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
