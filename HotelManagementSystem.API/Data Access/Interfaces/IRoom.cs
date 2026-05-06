using HotelManagementSystem.API.Domain.DTOs;
using HotelManagementSystem.API.Utility;

public interface IRoom
    {
        Task<ResponseDetails<RoomResponseDto>> CreateRoomAsync(CreateRoomDto dto);
        Task<ResponseDetails<RoomResponseDto>> UpdateRoomAsync(Guid id, UpdateRoomDto dto);
        Task<ResponseDetails<RoomResponseDto>> GetRoomByIdAsync(Guid id);
        Task<ResponseDetails<PagedResponse<RoomResponseDto>>> GetRoomsByFilterAsync(RoomFilterDto filter);
        //Task<ResponseDetails<IEnumerable<RoomResponseDto>>> GetAvailableRoomsAsync();
        Task<ResponseDetails<RoomResponseDto>> DeleteAsync(Guid id);
    }

