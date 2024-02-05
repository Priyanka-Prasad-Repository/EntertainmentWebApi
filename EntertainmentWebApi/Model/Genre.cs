using System.ComponentModel.DataAnnotations;

namespace EntertainmentWebApi.Model
{
    /// <summary>
    /// Model class for genre
    /// </summary>
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }
        [MaxLength(50)]
        public required string GenreTitle { get; set; }

        public ICollection<Movie>? Movies { get; set; }
    }
}
