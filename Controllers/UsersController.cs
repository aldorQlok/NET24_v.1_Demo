using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NET24FilmBorrowSystem.Data;
using NET24FilmBorrowSystem.DTOs.MovieDTOs;
using NET24FilmBorrowSystem.DTOs.UserDTOs;
using NET24FilmBorrowSystem.DTOs.UserMoviesDTOs;
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
        private readonly AppDBContext _context;
        public UsersController(IUserService userService, IConfiguration config, AppDBContext context)
        {
            _userService = userService;
            _config = config;
            _context = context;
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

        [HttpGet("{id:int}/movies")]
        public async Task<IActionResult> UserMovies(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);

            var userMovies = new UserMoviesDTO
            {
                User = user
            };

            var movies = await _context.UserMovies.Where(um => um.FK_UserId == id && um.ReturnDate == null)
                .Include(m => m.Movie).Select(m =>
                new MovieDTO
                {
                    Id = m.FK_MovieId,
                    Title = m.Movie.Title,
                    ReleaseYear = m.Movie.ReleaseYear,
                }).ToListAsync();

            userMovies.Movies = movies;

            return Ok(userMovies);
        }

        [HttpPost("{userId:int}/movies/{movieId:int}/borrow")]
        public async Task<IActionResult> BorrowMovie(int userId, int movieId)
        {
            // OBS: Should first check if user exists and if movie is truly available before the following code.

            var borrow = new UserMovies
            {
                FK_UserId = userId,
                FK_MovieId = movieId,
                BorrowDate = DateTime.UtcNow,
            };

            _context.UserMovies.Add(borrow);
            await _context.SaveChangesAsync();

            return Created();
        }

        [HttpPost("{userId:int}/movies/{movieId:int}/return")]
        public async Task<IActionResult> ReturnMovie(int userId, int movieId)
        {
            // OBS: Should first check if user exists and if movie is truly available before the following code.

            var movie = await _context.UserMovies.FirstOrDefaultAsync(um => um.FK_UserId == userId && um.FK_MovieId == movieId);
            if (movie == null)
            {
                return BadRequest();
            }

            movie.ReturnDate = DateTime.UtcNow;
            _context.UserMovies.Update(movie);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
