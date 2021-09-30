using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeendokLista.Data.Models
{
    [Table("Felhasznalok")]
    [Index(nameof(Felhasznalonev), IsUnique = true)]
    public class Felhasznalo
    {
        public Felhasznalo()
        {
            Feladatok = new HashSet<Feladat>();
        }

        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Felhasznalonev { get; set; }
        [Required]
        [StringLength(255)]
        [DataType(DataType.Password)]
        public string Jelszo { get; set; }

        public ICollection<Feladat> Feladatok { get; set; }
    }
}
