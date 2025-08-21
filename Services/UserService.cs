using NET24FilmBorrowSystem.DTOs.UserDTOs;
using NET24FilmBorrowSystem.Models;
using NET24FilmBorrowSystem.Repositories.IRepositories;
using NET24FilmBorrowSystem.Services.IServices;

namespace NET24FilmBorrowSystem.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;
        public UserService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<List<UserDTO>> GetAllUsersAsync()
        {
            var users = await _userRepo.GetAllUsersAsync();

            var usersDTO = users.Select(u => new UserDTO
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email
            }).ToList();

            return usersDTO;
        }

        public async Task<UserDTO> GetUserByIdAsync(int userId)
        {
            var user = await _userRepo.GetUserByIdAsync(userId);
            if (user == null)
            {
                return null;
            }


            var userDTO = new UserDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };

            return userDTO;
        }

        public async Task<int> CreateUserAsync(UserDTO userDTO)
        {
            var user = new User
            {
                Name = userDTO.Name,
                Email = userDTO.Email,
            };

            var newUserId = await _userRepo.AddUserAsync(user);

            return newUserId;
        }


        public Task<bool> UpdateUserAsync(UserDTO userDTO)
        {
            throw new NotImplementedException();
        }
        

        public Task<bool> DeleteUserAsync(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
