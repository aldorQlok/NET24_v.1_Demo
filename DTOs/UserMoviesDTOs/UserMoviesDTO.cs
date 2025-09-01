using NET24FilmBorrowSystem.DTOs.MovieDTOs;
using NET24FilmBorrowSystem.DTOs.UserDTOs;

namespace NET24FilmBorrowSystem.DTOs.UserMoviesDTOs
{
    public class UserMoviesDTO
    {
        public UserDTO User { get; set; }

        public List<MovieDTO> Movies { get; set; }
    }
}
