using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviApp.Models
{
    public class PersonGenere
    {
        [Key]
        //qouto intecriment of id 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int personGenereId { get; set; }

        [ForeignKey("PersonId")]
        public Person? FK_persond { get; set; } 
        [ForeignKey("GenerId")]
        public Genre? FK_GenerId { get; set; } 
    }
}
