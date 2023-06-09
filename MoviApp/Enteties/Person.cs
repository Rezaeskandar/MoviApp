﻿using MoviApp.Enteties;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviApp.Models
{
    public class Person
    {
        [Key]
        //aouto intecriment of id 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PersonId { get; set; }
        [Required]
        [MaxLength(60)]
        [Column (TypeName = "varchar(60)")]
        public string? Name { get; set; }
        [Required]
        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string? Email { get; set; }

        public List<PersonGenere>? PersonGenere { get; set; }
        public List<Rating>? Ratings { get; set; }
        public List<Movie>? Movies { get; set; }


    }
}
