using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeendokLista.DAL.Models
{
    // TODO: javítás
    // [Table("Felhasznalok")]
    [Index(nameof(Felhasznalonev), IsUnique = true)]
    public class Felhasznalo
    {
        public Felhasznalo()
        {
            //Feladatok = new HashSet<Feladat>();
        }

        public int Id { get; set; }
        [Required]
        public string Felhasznalonev { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Jelszo { get; set; }

        //public virtual ICollection<Feladat> Feladatok { get; set; }
    }
}
