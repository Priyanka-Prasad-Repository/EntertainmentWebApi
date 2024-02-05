using EntertainmentWebApi.Model;
using Microsoft.EntityFrameworkCore;

namespace EntertainmentWebApi
{
    /// <summary>
    /// Application Db context for creating dynamically models along with relevant data
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        #region Tables
        public virtual DbSet<Movie> Movies { get; set; }

        public virtual DbSet<Actor> Actors { get; set; }

        public virtual DbSet<Director> Directors { get; set; }

        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }

        #endregion

        /// <summary>
        /// One to many relationship for actor and movie model.Eg One actor can have many movies
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Relationships
            modelBuilder.Entity<Actor>()
            .HasMany(c => c.Movies)
            .WithOne(c => c.Actor);

            modelBuilder.Entity<Director>()
           .HasMany(c => c.Movies)
           .WithOne(c => c.Director);

            modelBuilder.Entity<Genre>()
           .HasMany(c => c.Movies)
           .WithOne(c => c.Genre);

            modelBuilder.Entity<Review>()
            .HasOne(c => c.Movies)
            .WithMany(c => c.Reviews).HasForeignKey(s => s.MovieId);

            modelBuilder.Entity<Movie>()
           .HasOne(c => c.Actor)
           .WithMany(f => f.Movies).HasForeignKey(s => s.actorId).IsRequired();

            modelBuilder.Entity<Movie>()
            .HasOne(c => c.Genre)
            .WithMany(f => f.Movies).HasForeignKey(s => s.GenreId).IsRequired();

            modelBuilder.Entity<Movie>()
            .HasOne(c => c.Director)
            .WithMany(f => f.Movies).HasForeignKey(s => s.directorId).IsRequired();

            modelBuilder.Entity<Movie>()
            .HasMany(c => c.Reviews)
            .WithOne(f => f.Movies);

            #endregion


            #region Data Load

            modelBuilder.Entity<Actor>().HasData(
            new Actor()
            { Id = 1, ActName = "Ranbir Kapoor", ActGender = "M" },
            new Actor()
            { Id = 2, ActName = "Alia Bhatt", ActGender = "F" },
              new Actor()
              { Id = 3, ActName = "Priyanka Chopra", ActGender = "F" },
            new Actor()
            { Id = 4, ActName = "Amitabh Bacchan", ActGender = "M" },
              new Actor()
              { Id = 5, ActName = "Ajay Devagan", ActGender = "M" },
             new Actor()
             { Id = 6, ActName = "Arshad Warsi", ActGender = "M" },
             new Actor()
             { Id = 7, ActName = "Sharukh Khan", ActGender = "M" },
             new Actor()
             { Id = 8, ActName = "Pooja Bhatt", ActGender = "F" }


           );


            modelBuilder.Entity<Director>().HasData(
            new Director()
            { DirId = 101, DirName = "Alia Bhatt" },
            new Director()
            { DirId = 102, DirName = "Rohit Shetty" },
             new Director()
             { DirId = 103, DirName = "Pooja Bhatt" },
            new Director()
            { DirId = 104, DirName = "Sharukh Khan" },
             new Director()
             { DirId = 105, DirName = "NTR" },
              new Director()
              { DirId = 106, DirName = "Karan Johar" });


            modelBuilder.Entity<Genre>().HasData(
          new Genre()
          { GenreId = 1001, GenreTitle = "Horror" },
          new Genre()
          { GenreId = 1002, GenreTitle = "Sci-Fiction" },
           new Genre()
           { GenreId = 1003, GenreTitle = "Comedy" },
           new Genre()
           { GenreId = 1004, GenreTitle = "Drama" });



            modelBuilder.Entity<Movie>().HasData(
             new Movie()
             {
                 MovId = 801,
                 MovLang = "PAN India",
                 MovReleaseCountry = "Worldwide",
                 MovRelDate = DateTime.Now,
                 MovTitle = "Brahmastra",
                 MovYear = 2024,
                 actorId = 2,
                 directorId = 101,
                 GenreId = 1002

             },
              new Movie()
              {
                  MovId = 802,
                  MovLang = "PAN India",
                  MovReleaseCountry = "Worldwide",
                  MovRelDate = DateTime.Now,
                  MovTitle = "RRR",
                  MovYear = 2024,
                  actorId = 5,
                  directorId = 103,
                  GenreId = 1003,

              }
             );

            modelBuilder.Entity<Review>().HasData(
              new Review()
              { ReviewId = 201, ReviewTitle = "1 star", ReviewText = "Rotten tomatotes", MovieId = 801 },
            new Review()
            { ReviewId = 202, ReviewTitle = "1 star", ReviewText = "Very Bad movie", MovieId = 801 },
            new Review()
            { ReviewId = 203, ReviewTitle = "4 star", ReviewText = "Fantastic movie", MovieId = 801 });

            #endregion

        }

    }
}
