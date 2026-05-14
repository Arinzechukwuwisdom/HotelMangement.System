using HotelManagementSystem.API.Context;
using HotelManagementSystem.API.Data_Access.Interfaces;
using HotelManagementSystem.API.Domain.DTOs;
using HotelManagementSystem.API.Domain.Models;
using HotelManagementSystem.API.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HotelManagementSystem.API.Data_Access.Repository
{
    public class RoomRepository : IRoom
    {
        public readonly HotelContext _context;
        ILogger<RoomRepository> _logger;

        public RoomRepository(HotelContext context, ILogger<RoomRepository> logger) 
        { 
            _context = context;
            _logger = logger;

        }
        public async Task<ResponseDetails<RoomResponseDto>> CreateRoomAsync(CreateRoomDto dto)
        {
            try
            {
                var roomExists = await _context.Rooms
                .AnyAsync(x => x.RoomNo == dto.RoomNo);

                if (roomExists)
                {
                    return new ResponseDetails<RoomResponseDto>
                    {
                        IsSuccess = false,
                        Message = "Room already Exists",
                        Data= null
                    };
                }
                    var room = new Room
                    {
                        RoomNo = dto.RoomNo,
                        Price = dto.PricePerNight,
                        RoomStatus = dto.RoomStatus,
                        RoomType = dto.RoomType,
                    };
                await _context.Rooms.AddAsync(room);
                await _context.SaveChangesAsync();

                var response = new RoomResponseDto
                {
                    Id = room.Id,
                    RoomNo = room.RoomNo,
                    RoomType = room.RoomType,
                    Price = room.Price,
                    IsAvailable = room.IsAvailable,
                    RoomStatus = room.RoomStatus,
                };

                return new ResponseDetails<RoomResponseDto>
                {
                    IsSuccess = true,
                    Message = "Room created successfully",
                    Data = response
                };
            }

            catch (Exception ex) 
            {
                _logger.LogError(ex, "Error occurred while creating room with roomNo: {RoomNo}", dto.RoomNo);

                return new ResponseDetails<RoomResponseDto>
                {
                    IsSuccess = false,
                    Message = $"An error occurred: {ex.Message}",
                    Data = null
                };
            }
        }

        public async Task<ResponseDetails<RoomResponseDto>> DeleteAsync(Guid id)
        {
            try
            {
                var room = await _context.Rooms.FindAsync(id);
                if (room == null)
                {
                    return new ResponseDetails<RoomResponseDto>
                    {
                        IsSuccess = false,
                        Message = "Room not Found",
                        Data = null
                    };
                }
                _context.Rooms.Remove(room);
                await _context.SaveChangesAsync();
                return new ResponseDetails<RoomResponseDto>
                {
                    IsSuccess = true,
                    Message = "Customer Deleted Successfully"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting room with roomNo: {roomNo}", id);

                return new ResponseDetails<RoomResponseDto>
                {
                    IsSuccess = false,
                    Message = "An error occurred while deleting the room"
                };
            }
        }


        public async Task<ResponseDetails<RoomResponseDto>> GetRoomByIdAsync(Guid id)
        {
            try
            {
                var room = await _context.Rooms.FindAsync(id);

                if (room == null) 
                {
                    return new ResponseDetails<RoomResponseDto>
                    {
                        IsSuccess = false,
                        Message = "Room not found",
                        Data = null
                    };
                }
                return new ResponseDetails<RoomResponseDto>
                {
                    IsSuccess = true,
                    Message = "Customer fetched Successfully"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while finding room with id: {id}", id);

                return new ResponseDetails<RoomResponseDto>
                {
                    IsSuccess = false,
                    Message = "An error occurred while finding the room"
                };
            }
        }



        public async Task<ResponseDetails<PagedResponse<RoomResponseDto>>> GetRoomsByFilterAsync(RoomFilterDto filter)
        {
            try
            {
                var query = _context.Rooms.AsQueryable();

                // Filtering
                if (!string.IsNullOrEmpty(filter.RoomType))
                    query = query.Where(r => r.RoomType == filter.RoomType);

                if (filter.MinPrice.HasValue)
                    query = query.Where(r => r.Price >= filter.MinPrice.Value);

                if (filter.MaxPrice.HasValue)
                    query = query.Where(r => r.Price <= filter.MaxPrice.Value);

                if (filter.IsAvailable.HasValue)
                    query = query.Where(r => r.IsAvailable == filter.IsAvailable.Value);

                // Total count BEFORE pagination
                var totalCount = await query.CountAsync();

                // Pagination
                var rooms = await query
                    .Skip((filter.PageNumber - 1) * filter.PageSize)
                    .Take(filter.PageSize)
                    .ToListAsync();

                // Map to DTO
                var roomDtos = rooms.Select(r => new RoomResponseDto
                {
                    Id = r.Id,
                    RoomNo = r.RoomNo,
                    RoomType = r.RoomType,
                    Price = r.Price,
                    IsAvailable = r.IsAvailable
                });

                return new ResponseDetails<PagedResponse<RoomResponseDto>>
                {
                    IsSuccess = true,
                    Message = "Rooms retrieved successfully",
                    Data = new PagedResponse<RoomResponseDto>
                    {
                        Data = roomDtos,
                        PageNumber = filter.PageNumber,
                        PageSize = filter.PageSize,
                        TotalCount = totalCount
                    }
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while filtering rooms");

                return new ResponseDetails<PagedResponse<RoomResponseDto>>
                {
                    IsSuccess = false,
                    Message = "An error occurred while retrieving rooms"
                };
            }
        }

        public async Task<ResponseDetails<RoomResponseDto>> UpdateRoomAsync(Guid id, UpdateRoomDto dto)
        {
            try
            {
                var room = await _context.FindAsync<Room>(id);
                if (room == null)
                {
                    return new ResponseDetails<RoomResponseDto>
                    {
                        IsSuccess = false,
                        Message = "Room Not Found",
                        Data = null
                    };
                }
                room.RoomType = dto.RoomType ?? room.RoomType;

                room.RoomNo = (dto.RoomNo != null) 
                    ? dto.RoomNo
                    : room.RoomNo;

                room.Price = (dto.Price != null)
                    ? dto.Price
                    : room.Price;

                room.RoomStatus = (dto.RoomStatus != null)
                    ? dto.RoomStatus
                    : room.RoomStatus;

                await _context.SaveChangesAsync();
                var roomResponseDTO = new RoomResponseDto
                {
                    RoomNo = room.RoomNo,
                    RoomStatus = room.RoomStatus,
                    RoomType = room.RoomType,
                    Price = room.Price,
                };

                return new ResponseDetails<RoomResponseDto>
                {
                    IsSuccess = true,
                    Data = roomResponseDTO,
                    Message = "Room Updated Successfully"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating customer with id: {id}", id);

                return new ResponseDetails<RoomResponseDto>
                {
                    IsSuccess = false,
                    Message = "An error occurred while updating customer"
                };
            }
        }
    }
}
