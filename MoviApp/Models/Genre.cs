using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviApp.Models
{
    public class Genre
    {
        
        public int GenerId { get; set; }

        [Required]
        [MaxLength(150)]
        [Column(TypeName = "varchar(150)")]
        public string? Title { get; set; }

        [MaxLength(400)]
        [Column(TypeName = "varchar(400)")]
        public string? Description { get; set; } = null;
        
    }
}
