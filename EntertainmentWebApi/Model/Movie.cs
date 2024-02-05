using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;


namespace EntertainmentWebApi.Model
{
    /// <summary>
    /// Model class for Movie
    /// </summary>
    public class Movie
    {
        [Key]
        [Required]
        public int MovId { get; set; }
        [MaxLength(100)]
        public required string MovTitle { get; set; }
        public int MovYear { get; set; }
        [MaxLength(50)]
        public required string MovLang { get; set; }
        [MaxLength(50)]
        public required string MovReleaseCountry { get; set; }
        public DateTime MovRelDate { get; set; }

        [ForeignKey("FK_Movies_Actors_mov_id")]
        public int actorId { get; set; }

        [ForeignKey("FK_Movies_Directors_mov_id")]
        public int directorId { get; set; }

        [ForeignKey("FK_Movies_Genres_mov_id")]
        public int GenreId { get; set; }

       
        public virtual Actor? Actor { get; set; }
      
        public virtual Genre? Genre { get; set; }
       
        public virtual Director? Director { get; set; }
      
        public virtual ICollection<Review>? Reviews { get; set; }
    }
}
