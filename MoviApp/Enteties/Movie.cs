using MoviApp.Enteties;
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

        //[ForeignKey("personGenereId")]
        //public PersonGenere? person_GenereId { get; set; } 
        //[Required]
        [Column(TypeName = "varchar(100)")]
        public string? Name { get; set; }
        [Required]
        [Column (TypeName = "varchar(255)")]
        public string? Movelink { get; set; }

        public List<Rating>? Rating { get; set; } 
       
        //public int Genered { get; set; }
        //public  Genre? Geners { get; set; }
        //public int Personed { get; set; }
        public int FkPersonId { get; set; }
        public virtual Person? persons { get; set; }
        public List<MovieGenre>? MovieGenre { get; set; }
       
    }
}
