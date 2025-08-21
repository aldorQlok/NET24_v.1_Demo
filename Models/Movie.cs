using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace NET24FilmBorrowSystem.Models
{
    [Index(nameof(Title), nameof(ReleaseYear), IsUnique = true)]
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(200)]
        public string Title { get; set; }

        [Required]
        public int? ReleaseYear { get; set; }

        public List<UserMovies> UserMovies { get; set; }
    }
}
