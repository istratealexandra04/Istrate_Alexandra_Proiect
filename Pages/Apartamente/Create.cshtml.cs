using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Istrate_Alexandra_Proiect.Data;
using Istrate_Alexandra_Proiect.Models;

namespace Istrate_Alexandra_Proiect.Pages.Apartamente
{
    public class CreateModel : CartiereApartamentPageModel
    {
        private readonly Istrate_Alexandra_Proiect.Data.Istrate_Alexandra_ProiectContext _context;

        public CreateModel(Istrate_Alexandra_Proiect.Data.Istrate_Alexandra_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["AngajatID"] = new SelectList(_context.Set<Angajat>(), "ID", "NumePrenumeAngajat");
            var apartament = new Apartament();
            apartament.CartiereApartament = new List<CartierApartament>();
            PopulateAssignedCartierData(_context, apartament);
            return Page();
        }

        [BindProperty]
        public Apartament Apartament { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedCartiere)
        {
            var newApartament = new Apartament();
            if (selectedCartiere != null)
            {
                newApartament.CartiereApartament = new List<CartierApartament>();
                foreach (var car in selectedCartiere)
                {
                    var carToAdd = new CartierApartament
                    {
                        CartierID = int.Parse(car)
                    };
                    newApartament.CartiereApartament.Add(carToAdd);
                }
            }
            if (await TryUpdateModelAsync<Apartament>(
            newApartament,
            "Apartament",
            i => i.ApId, i => i.Adresa,
            i => i.Pret, i => i.Descriere, i=> i.DataPublicare, i => i.AngajatID))
            {
                _context.Apartament.Add(newApartament);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCartierData(_context, newApartament);
            return Page();
        }
    }
}
