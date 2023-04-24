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

        [ForeignKey("personGenereId")]
        public Person?FK_person { get; set; }
        public int FK_personId { get; set; }
        [ForeignKey("personGenereId")]
        public Genre? FK_Gener { get; set; }
        public int FK_GenreId { get; set; }





    }
}
