using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Istrate_Alexandra_Proiect.Data;
using Istrate_Alexandra_Proiect.Models;

namespace Istrate_Alexandra_Proiect.Pages.Angajati
{
    public class IndexModel : PageModel
    {
        private readonly Istrate_Alexandra_Proiect.Data.Istrate_Alexandra_ProiectContext _context;

        public IndexModel(Istrate_Alexandra_Proiect.Data.Istrate_Alexandra_ProiectContext context)
        {
            _context = context;
        }

        public IList<Angajat> Angajat { get;set; }

        public async Task OnGetAsync()
        {
            Angajat = await _context.Angajat.ToListAsync();
        }
    }
}
