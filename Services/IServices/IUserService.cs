using NET24FilmBorrowSystem.DTOs.UserDTOs;

namespace NET24FilmBorrowSystem.Services.IServices
{
    public interface IUserService
    {
        Task<List<UserDTO>> GetAllUsersAsync();
        Task<UserDTO> GetUserByIdAsync(int userId);
        Task<int> CreateUserAsync(UserDTO userDTO);
        Task<bool> UpdateUserAsync(UserDTO userDTO);
        Task<bool> DeleteUserAsync(int userId);
    }
}
