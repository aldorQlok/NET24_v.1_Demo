using System.ComponentModel.DataAnnotations;

namespace NET24FilmBorrowSystem.DTOs.MovieDTOs
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? ReleaseYear { get; set; }
    }
}
