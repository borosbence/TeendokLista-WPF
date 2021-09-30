using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeendokLista.DAL.Models
{
    [Table("feladat")]
    public partial class Feladat
    {
        // [Key, Column("Id")]
        public int id { get; set; }
        [Required]
        [StringLength(50)]
        public string cim { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string szoveg { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime letrehozas_datum { get; set; }
        public bool teljesitve { get; set; }

        //[ForeignKey("Felhasznalo")]
        //public int FelhasznaloId { get; set; }

        //public Felhasznalo Felhasznalo { get; set; }
    }
}
