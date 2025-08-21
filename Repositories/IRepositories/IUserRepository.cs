using NET24FilmBorrowSystem.Models;

namespace NET24FilmBorrowSystem.Repositories.IRepositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int userId);
        Task<int> AddUserAsync(User user);
        Task<bool> UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(int userId);
    }
}
