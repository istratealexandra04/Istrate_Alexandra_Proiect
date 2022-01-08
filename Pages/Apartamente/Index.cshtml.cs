using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Istrate_Alexandra_Proiect.Data;
using Istrate_Alexandra_Proiect.Models;

namespace Istrate_Alexandra_Proiect.Pages.Apartamente
{
    public class IndexModel : PageModel
    {
        private readonly Istrate_Alexandra_Proiect.Data.Istrate_Alexandra_ProiectContext _context;

        public IndexModel(Istrate_Alexandra_Proiect.Data.Istrate_Alexandra_ProiectContext context)
        {
            _context = context;
        }

        public IList<Apartament> Apartament { get;set; }

        public ApartamentData ApartamentD { get; set; }
        public int ApartamentID { get; set; }
        public int CartierID { get; set; }
        public async Task OnGetAsync(int? id, int? cartierID)
        {
            ApartamentD = new ApartamentData();

            ApartamentD.Apartamente = await _context.Apartament
            .Include(b => b.Angajat)
            .Include(b => b.CartiereApartament)
            .ThenInclude(b => b.Cartier)
            .AsNoTracking()
            .OrderBy(b => b.Pret)
            .ToListAsync();
            if (id != null)
            {
                ApartamentID = id.Value;
                Apartament apartament = ApartamentD.Apartamente
                .Where(i => i.ID == id.Value).Single();
                ApartamentD.Cartiere = apartament.CartiereApartament.Select(s => s.Cartier);
            }
        }
    }
}
