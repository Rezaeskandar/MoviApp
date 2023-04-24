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
        //connection
        public ApiDbContext(DbContextOptions<ApiDbContext> options)
            : base(options)
        {

        }

        //one opption for connetion
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("connetionstring")
        //}


        //Seeding data in database
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Genre>().HasData(
        //        new Genre()
        //        {
        //            GenerId= 1,
        //            Title = "Legal drama",
        //            Description = "The most sold film and emotianl int not recomends for pepole under 14."
        //        },
        //         new Genre()
        //         {
        //             GenerId = 2,
        //             Title = "drama",
        //             Description = "The most sold film and emotianl int not recomends for pepole under 20."
        //         });


        //    modelBuilder.Entity<Person>().HasData(
        //        new Person()
        //        {
        //            PersonId= 1,
        //            Name = "reza",
        //            Email = "Rezaeskand@gmail.com"
        //        },
        //        new Person()
        //        {
        //            PersonId = 2,
        //            Name = "Rasoul",
        //            Email = "Rasouleskand@gmail.com"
                
        //        });


        //    modelBuilder.Entity<PersonGenere>().HasData(
        //        new PersonGenere()
        //        {
        //            personGenereId=1,
                 
        //        },
        //        new PersonGenere()
        //        {
        //          personGenereId=2

        //        });

        //    modelBuilder.Entity<Movie>().HasData(
        //       new Movie()
        //       {
        //           MovieId = 1,
        //           Movelink = "https://www.themoviedb.org/movie/19973-comedian",
                 
        //           Rating= 5
                   
        //       },
        //       new Movie()
        //       {
        //           MovieId = 2,
        //           Movelink = "https://www.themoviedb.org/movie/79168-drama",
        //           Rating = 3

        //       });
        //    base.OnModelCreating(modelBuilder);

        //}
    }
}
