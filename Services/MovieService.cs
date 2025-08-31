using NET24FilmBorrowSystem.DTOs.MovieDTOs;
using NET24FilmBorrowSystem.Models;
using NET24FilmBorrowSystem.Repositories.IRepositories;
using NET24FilmBorrowSystem.Services.IServices;

namespace NET24FilmBorrowSystem.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepo;

        public MovieService(IMovieRepository movieRepo)
        {
            _movieRepo = movieRepo;
        }
        public async Task<int> CreateMovieAsync(MovieDTO movieDTO)
        {
            var movie = new Movie
            {
                Title = movieDTO.Title,
                ReleaseYear = movieDTO.ReleaseYear,
            };

            var newMovieId = await _movieRepo.AddMovieAsync(movie);

            return newMovieId;
        }

        public async Task<bool> DeleteMovieAsync(int movieId)
        {
            var removed = await _movieRepo.DeleteMovieAsync(movieId);

            if (!removed)
            {
                return false;
            }

            return true;
        }

        public async Task<List<MovieDTO>> GetAllMoviesAsync()
        {
            var movies = await _movieRepo.GetAllMoviesAsync();

            var movieDTO = movies.Select(u => new MovieDTO
            {
                Id = u.Id,
                Title = u.Title,
                ReleaseYear = u.ReleaseYear,
            }).ToList();

            return movieDTO;
        }

        public async Task<MovieDTO> GetMovieByIdAsync(int movieId)
        {
            var movie = await _movieRepo.GetMovieByIdAsync(movieId);
            if (movie == null)
            {
                return null;
            }

            var movieDTO = new MovieDTO
            {
                Id = movieId,
                Title = movie.Title,
                ReleaseYear = movie.ReleaseYear,
            };

            return movieDTO;
        }

        public async Task<bool> UpdateMovieAsync(MovieDTO movieDTO)
        {
            var movie = await _movieRepo.GetMovieByIdAsync(movieDTO.Id);
            if (movie == null)
            {
                return false;
            }

            if(!string.IsNullOrEmpty(movieDTO.Title))
            {
                movie.Title = movieDTO.Title;
            }

            if(movieDTO.ReleaseYear != 0)
            {
                movie.ReleaseYear = movieDTO.ReleaseYear;
            }

            await _movieRepo.UpdateMovieAsync(movie);

            return true;
        }
    }
}
