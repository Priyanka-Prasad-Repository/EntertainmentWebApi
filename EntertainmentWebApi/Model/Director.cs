using System.ComponentModel.DataAnnotations;

namespace EntertainmentWebApi.Model
{
    /// <summary>
    /// Model class for director
    /// </summary>
    public class Director
    {

        [Key]
        public int DirId { get; set; }

        [MaxLength(100)]
        public required string DirName { get; set; }

        public ICollection<Movie>? Movies { get; set; }
    }
}
