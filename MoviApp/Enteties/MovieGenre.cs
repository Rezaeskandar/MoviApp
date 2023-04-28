using MoviApp.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviApp.Enteties
{
    public class MovieGenre
    {
        [Key]
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int FkGenreId { get; set; }
        public virtual Genre? Genres { get; set; }
        public int FkMovieId { get; set; }
        public virtual Movie? Movies { get; set; }
        public string? NewLink { get; set; }
     

    }
}
