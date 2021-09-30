using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeendokLista.Data.Models
{
    [Table("Feladatok")]
    public partial class Feladat
    {
        //[Key, Column("Id")]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Cim { get; set; }
        [Required]
        [Column(TypeName = "text")]
        [DataType(DataType.MultilineText)]
        public string Szoveg { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime LetrehozasDatum { get; set; }
        public bool Teljesitve { get; set; }

        //[ForeignKey("Felhasznalo")]
        //public int FelhasznaloId { get; set; }

        public Felhasznalo Felhasznalo { get; set; }
    }
}
