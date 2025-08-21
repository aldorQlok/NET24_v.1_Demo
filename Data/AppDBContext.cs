using Microsoft.EntityFrameworkCore;
using NET24FilmBorrowSystem.Models;

namespace NET24FilmBorrowSystem.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<UserMovies> UserMovies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var userEntity = modelBuilder.Entity<User>();

            userEntity.HasIndex(u => u.Email);
            userEntity.HasIndex(u => u.Email).IsUnique();

            //userEntity.HasData(
            //    new User { Id = 1, Name = "Aldor_Qlok", Email = "Aldor@gmail.com" },
            //    new User { Id = 2, Name = "Tobias", Email = "Tobias@gmail.com" }
            //    );

            var movieEntity = modelBuilder.Entity<Movie>();
            movieEntity.HasIndex(m => new { m.Title, m.ReleaseYear }).IsUnique();

            //movieEntity.HasData(
            //    new Movie { Id = 1, Title = "The Conjuring", ReleaseYear = 2013 }
            //    );

            //var userMoviesEntity = modelBuilder.Entity<UserMovies>();
            //userMoviesEntity.HasData(new UserMovies { Id=1, FK_MovieId=1, FK_UserId=1, BorrowDate = new DateTime(2013,01,01)});
        }
    }
}
