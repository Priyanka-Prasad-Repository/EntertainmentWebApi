using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EntertainmentWebApi.Model
{
    /// <summary>
    /// Model class for Movie
    /// </summary>
    public class Movie
    {
        [Key]
        [Required]
        public int mov_id { get; set; }
        [MaxLength(100)]
        public string mov_title { get; set; }
        public int mov_year { get; set; }
        [MaxLength(50)]
        public string mov_lang { get; set; }
        [MaxLength(50)]
        public string mov_release_country { get; set; }
        public DateTime mov_rel_date { get; set; }

        [ForeignKey("FK_Movies_Actors_mov_id")]
        public int actor_id { get; set; }

        [ForeignKey("FK_Movies_Directors_mov_id")]
        public int director_id { get; set; }

        [ForeignKey("FK_Movies_Genres_mov_id")]
        public int genre_id { get; set; }


        public Actor Actor { get; set; }
        public Genre Genre { get; set; }
        public Director Director { get; set; }

        public ICollection<Review> Reviews { get; set; }
    }
}
