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


        public async Task<bool> UpdateUserAsync(UserDTO userDTO)
        {
            var user = await _userRepo.GetUserByIdAsync(userDTO.Id);

            if(user == null)
            {
                return false;
            }

            if (!string.IsNullOrEmpty(userDTO.Name))
            {
                user.Name = userDTO.Name;
            }

            if (!string.IsNullOrEmpty(userDTO.Email))
            {
                user.Email = userDTO.Email;
            }

            await _userRepo.UpdateUserAsync(user);

            return true;
        }
        

        public async Task<bool> DeleteUserAsync(int userId)
        {
            var removed = await _userRepo.DeleteUserAsync(userId);

            if (!removed)
            {
                return false;
            }

            return true;
        }
    }
}
