﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviApp.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        [Required]
        [MaxLength(50)]
        [Column (TypeName = "varchar(50)")]
        public string? Name { get; set; }
        [Required]
        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string? Email { get; set; }
    }
}