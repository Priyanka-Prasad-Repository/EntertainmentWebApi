using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EntertainmentWebApi.Model
{
    /// <summary>
    /// Model class for actor 
    /// </summary>
    public class Actor
    {

        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public required string ActName { get; set; }

        [MaxLength(2)]
        public required string ActGender { get; set; }

        public ICollection<Movie>? Movies { get; set; }
    }
}
