using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Istrate_Alexandra_Proiect.Models;

namespace Istrate_Alexandra_Proiect.Data
{
    public class Istrate_Alexandra_ProiectContext : DbContext
    {
        public Istrate_Alexandra_ProiectContext (DbContextOptions<Istrate_Alexandra_ProiectContext> options)
            : base(options)
        {
        }

        public DbSet<Istrate_Alexandra_Proiect.Models.Apartament> Apartament { get; set; }

        public DbSet<Istrate_Alexandra_Proiect.Models.Angajat> Angajat { get; set; }

        public DbSet<Istrate_Alexandra_Proiect.Models.Cartier> Cartier { get; set; }
    }
}
