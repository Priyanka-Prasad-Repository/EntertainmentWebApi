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
        public int reviewId { get; set; }
        public string review_Title { get; set; }
        public string review_Text { get; set; }


        [ForeignKey("FK_Movies_Reviews_mov_id")]
        public int movieId { get; set; }
        public Movie Movies { get; set; }
    }
}
