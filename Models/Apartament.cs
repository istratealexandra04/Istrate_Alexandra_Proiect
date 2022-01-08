using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Istrate_Alexandra_Proiect.Models
{
    public class Apartament
    {
        public int ID { get; set; }
        [Display(Name = "ID")]
        public int ApId { get; set; }
        [Required, StringLength(70, MinimumLength = 10)]
        public string Adresa { get; set; }
        [Range(1, 1000000)]
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Pret { get; set; }
        [Required, StringLength(250, MinimumLength = 1)]
        public string Descriere { get; set; }
        [Display(Name = "Data")]
        [DataType(DataType.Date)]
        public DateTime DataPublicare { get; set; }
        public int AngajatID { get; set; }
        public Angajat Angajat { get; set; }
        [Display(Name = "Cartier")]
        public ICollection<CartierApartament> CartiereApartament { get; set; }
    }
}
