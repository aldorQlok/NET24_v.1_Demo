using Microsoft.EntityFrameworkCore;
using NET24FilmBorrowSystem.Data;
using NET24FilmBorrowSystem.Models;
using NET24FilmBorrowSystem.Repositories.IRepositories;

namespace NET24FilmBorrowSystem.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly AppDBContext _context;
        public MovieRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<int> AddMovieAsync(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            return movie.Id;
        }

        public async Task<bool> DeleteMovieAsync(int movieId)
        {
            var rowsAffected = await _context.Movies.Where(m => m.Id == movieId).ExecuteDeleteAsync();

            if (rowsAffected > 0)
            {
                return true;
            }

            return false;
        }

        public async Task<List<Movie>> GetAllMoviesAsync()
        {
            var movies = await _context.Movies.ToListAsync();

            return movies;
        }

        public async Task<Movie> GetMovieByIdAsync(int movieId)
        {
            var movie = await _context.Movies
                .FirstOrDefaultAsync(m => m.Id == movieId);

            return movie;
        }

        public async Task<bool> UpdateMovieAsync(Movie movie)
        {
            _context.Movies.Update(movie);
            var result = await _context.SaveChangesAsync();

            if (result != 0)
            {
                return true;
            }

            return false;
        }
    }
}
