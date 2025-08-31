using NET24FilmBorrowSystem.DTOs.MovieDTOs;

namespace NET24FilmBorrowSystem.Services.IServices
{
    public interface IMovieService
    {
        Task<List<MovieDTO>> GetAllMoviesAsync();
        Task<MovieDTO> GetMovieByIdAsync(int movieId);
        Task<int> CreateMovieAsync(MovieDTO movieDTO);
        Task<bool> UpdateMovieAsync(MovieDTO movieDTO);
        Task<bool> DeleteMovieAsync(int movieId);
    }
}
