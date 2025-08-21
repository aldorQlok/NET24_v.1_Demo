using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NET24FilmBorrowSystem.Models
{
    public class UserMovies
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int FK_UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Movie")]
        public int FK_MovieId { get; set; }
        public Movie Movie { get; set; }

        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
