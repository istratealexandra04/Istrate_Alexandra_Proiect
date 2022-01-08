using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Istrate_Alexandra_Proiect.Models
{
    public class ApartamentData
    {
        public IEnumerable<Apartament> Apartamente { get; set; }
        public IEnumerable<Cartier> Cartiere { get; set; }
        [Display(Name = "Cartier")]
        public IEnumerable<CartierApartament> CartiereApartamente { get; set; }
    }
}
