using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EntertainmentWebApi.Model
{
    /// <summary>
    /// Model class for Actor 
    /// </summary>
    public class Actor
    {

        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string act_name { get; set; }

        [MaxLength(2)]
        public string act_gender { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}
