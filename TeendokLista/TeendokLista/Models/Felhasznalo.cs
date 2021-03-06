using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TeendokLista.Models
{
    [Index(nameof(Felhasznalonev), Name = "IX_Felhasznalok_Felhasznalonev", IsUnique = true)]
    [Table("felhasznalok")]
    public partial class Felhasznalo
    {
        public Felhasznalo()
        {
            feladatok = new HashSet<Feladat>();
        }

        [Key]
        [Column(TypeName = "int(11)")]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Felhasznalonev { get; set; }
        [Required]
        [StringLength(255)]
        public string Jelszo { get; set; }

        [InverseProperty("Felhasznalo")]
        public virtual ICollection<Feladat> feladatok { get; set; }
    }
}
