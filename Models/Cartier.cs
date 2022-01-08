using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Istrate_Alexandra_Proiect.Models
{
    public class Cartier
    {
        public int ID { get; set; }
        [Required, StringLength(50, MinimumLength = 2)]
        [Display(Name = "Cartier")]
        public string NumeCartier { get; set; }
        public ICollection<CartierApartament> CartiereApartamente { get; set; }
    }
}
