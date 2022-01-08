using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Istrate_Alexandra_Proiect.Data;
using Istrate_Alexandra_Proiect.Models;

namespace Istrate_Alexandra_Proiect.Pages.Apartamente
{
    public class EditModel : CartiereApartamentPageModel
    {
        private readonly Istrate_Alexandra_Proiect.Data.Istrate_Alexandra_ProiectContext _context;

        public EditModel(Istrate_Alexandra_Proiect.Data.Istrate_Alexandra_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Apartament Apartament { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

        Apartament = await _context.Apartament
        .Include(b => b.Angajat)
        .Include(b => b.CartiereApartament).ThenInclude(b => b.Cartier)
        .AsNoTracking()
        .FirstOrDefaultAsync(m => m.ID == id);

        if (Apartament == null)
            {
                return NotFound();
            }
        PopulateAssignedCartierData(_context, Apartament);
        ViewData["AngajatID"] = new SelectList(_context.Set<Angajat>(), "ID", "NumePrenumeAngajat");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCartiere)
    {
        if (id == null)
        {
            return NotFound();
        }
        var apartamentToUpdate = await _context.Apartament
        .Include(i => i.Angajat)
        .Include(i => i.CartiereApartament)
        .ThenInclude(i => i.Cartier)
        .FirstOrDefaultAsync(s => s.ID == id);
        if (apartamentToUpdate == null)
        {
            return NotFound();
        }
        if (await TryUpdateModelAsync<Apartament>(
        apartamentToUpdate,
        "Apartament",
        i => i.ApId, i => i.Adresa,
        i => i.Pret, i=>i.Descriere, i => i.DataPublicare, i => i.Angajat))
        {
            UpdateCartiereApartament(_context, selectedCartiere, apartamentToUpdate);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
        //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care 
        //este editata 
        UpdateCartiereApartament(_context, selectedCartiere, apartamentToUpdate);
        PopulateAssignedCartierData(_context, apartamentToUpdate);
        return Page();
    }
}
}
