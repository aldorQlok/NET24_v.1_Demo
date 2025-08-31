using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NET24FilmBorrowSystem.DTOs.MovieDTOs;
using NET24FilmBorrowSystem.Services.IServices;

namespace NET24FilmBorrowSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<ActionResult<List<MovieDTO>>> GetAllMovies()
        {
            var movies = await _movieService.GetAllMoviesAsync();

            return Ok(movies);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<MovieDTO>> GetMovieById(int id)
        {
            var movie = await _movieService.GetMovieByIdAsync(id);

            if(movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        [HttpPost]
        public async Task<ActionResult<MovieDTO>> CreateMovie(MovieDTO movie)
        {
            var movieId = await _movieService.CreateMovieAsync(movie);

            return CreatedAtAction(nameof(CreateMovie), new {id = movieId});
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateMovie(MovieDTO movie, int id)
        {
            var updated = await _movieService.UpdateMovieAsync(movie);

            if (!updated)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var removed = await _movieService.DeleteMovieAsync(id);

            if (!removed)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}
