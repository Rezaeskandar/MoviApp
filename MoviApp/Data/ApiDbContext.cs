using Microsoft.EntityFrameworkCore;
using MoviApp.Models;

namespace MoviApp.Data
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get;set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<PersonGenere> PersonGenere { get; set; }
        public ApiDbContext(DbContextOptions<ApiDbContext> options)
            : base(options)
        {

        }
        //one opption for connetion
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("connetionstring")
        //}
    }
}
