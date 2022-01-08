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
    public class DetailsModel : PageModel
    {
        private readonly Istrate_Alexandra_Proiect.Data.Istrate_Alexandra_ProiectContext _context;

        public DetailsModel(Istrate_Alexandra_Proiect.Data.Istrate_Alexandra_ProiectContext context)
        {
            _context = context;
        }

        public Apartament Apartament { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Apartament = await _context.Apartament.FirstOrDefaultAsync(m => m.ID == id);

            if (Apartament == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
