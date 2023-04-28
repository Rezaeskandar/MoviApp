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

        public int FK_personId { get; set; }
        public virtual Person? Persons { get; set; }

        public int FK_GenreId { get; set; }
        public virtual Genre? Genres { get; set; }

        public string? NewLinks { get; set; }
    



    }
}
