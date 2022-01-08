using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Istrate_Alexandra_Proiect.Models
{
    public class CartierApartament
    {
        public int ID { get; set; }
        public int ApartamentID { get; set; }
        public Apartament Apartament { get; set; }
        public int CartierID { get; set; }
        public Cartier Cartier { get; set; }
    }
}
