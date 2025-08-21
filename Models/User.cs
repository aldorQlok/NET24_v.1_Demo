using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace NET24FilmBorrowSystem.Models
{
    [Index(nameof(Email))]
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public List<UserMovies> UserMovies { get; set; }
    }
}
