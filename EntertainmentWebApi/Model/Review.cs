using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntertainmentWebApi.Model
{
    /// <summary>
    /// Model class for review
    /// </summary>
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        public required string ReviewTitle { get; set; }
        public required string ReviewText { get; set; }


        [ForeignKey("FK_Movies_Reviews_mov_id")]
        public int MovieId { get; set; }
        public Movie? Movies { get; set; }
    }
}
