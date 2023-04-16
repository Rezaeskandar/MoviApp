using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviApp.Models
{
    public class Movie
    {
        public int MovieId { get; set; }

        [Required] 
        public int personGenereId { get; set; }

        [Required]
        [Column (TypeName = "varchar")]
        public string? Movelink { get; set; }

        public int? Rating { get; set; } = null;
       
    }
}
