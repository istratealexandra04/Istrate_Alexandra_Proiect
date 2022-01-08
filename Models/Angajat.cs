using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Istrate_Alexandra_Proiect.Models
{
    public class Angajat
    {
        public int ID { get; set; }
        [RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$", ErrorMessage = "Numele angajatului trebuie sa fie de forma 'Nume prenume'"), Required, StringLength(50, MinimumLength = 5)]
        [Display(Name = "Angajat")]
        public string NumePrenumeAngajat { get; set; }
        public ICollection<Apartament> Apartamente { get; set; }
    }
}
