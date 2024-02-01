using System.ComponentModel.DataAnnotations;

namespace EntertainmentWebApi.Model
{
    /// <summary>
    /// Model class for Genre
    /// </summary>
    public class Genre
    {
        [Key]
        public int genre_id { get; set; }
        [MaxLength(50)]
        public string genre_title { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}
