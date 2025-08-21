using Microsoft.EntityFrameworkCore;
using NET24FilmBorrowSystem.Data;
using NET24FilmBorrowSystem.Models;
using NET24FilmBorrowSystem.Repositories.IRepositories;

namespace NET24FilmBorrowSystem.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDBContext _context;

        public UserRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<int> AddUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user.Id;
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            var rowsAffected = await _context.Users.Where(u => u.Id == userId).ExecuteDeleteAsync();

            if (rowsAffected > 0)
            {
                return true;
            }

            return false;

        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            var users = await _context.Users.ToListAsync();

            return users;
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Id == userId);

            return user;
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            var result = await _context.SaveChangesAsync();

            if (result != 0)
            {
                return true;
            }

            return false;

        }
    }
}
