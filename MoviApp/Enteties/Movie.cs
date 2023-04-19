using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviApp.Models
{
    public class Movie
    {
        [Key]
        //qouto intecriment of id 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MovieId { get; set; }

         [ForeignKey("personGenereId")]
        public PersonGenere? person_GenereId { get; set; } 

        [Required]
        [Column (TypeName = "varchar(255)")]
        public string? Movelink { get; set; }

        public int? Rating { get; set; } = null;
       
    }
}
