using EntertainmentWebApi.Model;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Reflection.Emit;

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
            .WithMany(c => c.Reviews).HasForeignKey(s=>s.movieId);

            modelBuilder.Entity<Movie>()
        .HasOne(c => c.Actor)
        .WithMany(f => f.Movies).HasForeignKey(s=>s.actor_id).IsRequired();

            modelBuilder.Entity<Movie>()
                .HasOne(c => c.Genre)
                .WithMany(f => f.Movies).HasForeignKey(s => s.genre_id).IsRequired();

            modelBuilder.Entity<Movie>()
                           .HasOne(c => c.Director)
                           .WithMany(f => f.Movies).HasForeignKey(s => s.director_id).IsRequired();

            modelBuilder.Entity<Movie>()
                          .HasMany(c => c.Reviews)
                          .WithOne(f => f.Movies);

            #endregion


            #region Data Load

            modelBuilder.Entity<Actor>().HasData(
            new Actor()
            { Id = 1, act_name = "Ranbir Kapoor", act_gender = "M" },
            new Actor()
            { Id = 2, act_name = "Alia Bhatt", act_gender = "F" },
              new Actor()
              { Id = 3, act_name = "Priyanka Chopra", act_gender = "F" },
            new Actor()
            { Id = 4, act_name = "Amitabh Bacchan", act_gender = "M" },
              new Actor()
              { Id = 5, act_name = "Ajay Devagan", act_gender = "M" },
             new Actor()
             { Id = 6, act_name = "Arshad Warsi", act_gender = "M" },
             new Actor()
             { Id= 7, act_name = "Sharukh Khan", act_gender = "M" },
             new Actor()
             { Id = 8, act_name = "Pooja Bhatt", act_gender = "F" }


           );


            modelBuilder.Entity<Director>().HasData(
            new Director()
            { dir_id = 101, dir_name = "Alia Bhatt" },
            new Director()
            { dir_id = 102, dir_name = "Rohit Shetty" },
             new Director()
             { dir_id = 103, dir_name = "Pooja Bhatt" },
            new Director()
            { dir_id = 104, dir_name = "Sharukh Khan" },
             new Director()
             { dir_id = 105, dir_name = "NTR" },
              new Director()
              { dir_id = 106, dir_name = "Karan Johar" });


            modelBuilder.Entity<Genre>().HasData(
          new Genre()
          { genre_id = 1001, genre_title = "Horror" },
          new Genre()
          { genre_id = 1002, genre_title = "Sci-Fiction" },
           new Genre()
           { genre_id = 1003, genre_title = "Comedy" },
           new Genre()
           { genre_id = 1004, genre_title = "Drama" });

          

            modelBuilder.Entity<Movie>().HasData(
             new Movie()
             {
                 mov_id = 801,
                 mov_lang = "PAN India",
                 mov_release_country = "Worldwide",
                 mov_rel_date = DateTime.Now,
                 mov_title = "Brahmastra",
                 mov_year = 2024,
                 actor_id = 2,
                 director_id = 101,
                 genre_id = 1002
                 
             },
              new Movie()
              {
                  mov_id = 802,
                  mov_lang = "PAN India",
                  mov_release_country = "Worldwide",
                  mov_rel_date = DateTime.Now,
                  mov_title = "RRR",
                  mov_year = 2024,
                  actor_id = 5,
                  director_id = 103,
                  genre_id = 1003

              }
             );

            modelBuilder.Entity<Review>().HasData(
              new Review()
              { reviewId = 201, review_Title = "1 star", review_Text = "Rotten tomatotes", movieId = 801 },
            new Review()
            { reviewId = 202, review_Title = "1 star", review_Text = "Very Bad movie", movieId = 801 },
            new Review()
            { reviewId = 203, review_Title = "4 star", review_Text = "Fantastic movie", movieId = 801 });

            #endregion

        }

    }
}
