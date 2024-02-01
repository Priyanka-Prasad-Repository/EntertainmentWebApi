using System.ComponentModel.DataAnnotations;

namespace EntertainmentWebApi.Model
{
    /// <summary>
    /// Model class for Director
    /// </summary>
    public class Director
    {

        [Key]
        public int dir_id { get; set; }

        [MaxLength(100)]
        public string dir_name { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}
