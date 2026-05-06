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
            var room = await _roomRepository.CreateRoomAsync(dto);
            return Ok(room);
        }
        [HttpGet]
        public async Task<IActionResult> GetRoomsByFilterAsync(RoomFilterDto filter)
        {
            var room = await _roomRepository.GetRoomsByFilterAsync(filter);
            return Ok(room);
        }

    }
}
