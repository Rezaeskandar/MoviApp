using MoviApp.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviApp.Enteties
{
    public class Rating
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RatingId { get; set; }
        public int? Ratings { get; set; } 
        public int? Fk_PersonId { get; set; }
        public virtual Person? Persons { get; set; }
        public int? FkMovieId { get; set; }
        public virtual Movie? Movies { get; set; }
    }
}
