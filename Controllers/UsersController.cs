using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NET24FilmBorrowSystem.DTOs.UserDTOs;
using NET24FilmBorrowSystem.Models;
using NET24FilmBorrowSystem.Services.IServices;

namespace NET24FilmBorrowSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _config;
        public UsersController(IUserService userService, IConfiguration config)
        {
            _userService = userService;
            _config = config;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDTO>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();

            return Ok(users);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<UserDTO>> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> CreateUser(UserDTO user)
        {
            var userId = await _userService.CreateUserAsync(user);


            return CreatedAtAction(nameof(GetAllUsers), new { id = userId });
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateUser(UserDTO user, int id)
        {
            var updated = await _userService.UpdateUserAsync(user);

            if (!updated)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var removed = await _userService.DeleteUserAsync(id);

            if (!removed)
            {
                return BadRequest();
            }

            return NoContent();
        }




        // Demo of getting data from different environments.

        //[HttpGet("TestMV")]
        //public IActionResult GetData()
        //{
        //    var data = _config["MittNamn"];
        //    if(data == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(data);
        //}
    }
}
