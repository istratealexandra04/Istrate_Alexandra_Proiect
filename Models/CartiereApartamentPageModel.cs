using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Istrate_Alexandra_Proiect.Data;

namespace Istrate_Alexandra_Proiect.Models
{
    public class CartiereApartamentPageModel : PageModel
    {
        public List<AssignedCartierData> AssignedCartierDataList;
        public void PopulateAssignedCartierData(Istrate_Alexandra_ProiectContext context,
            Apartament apartament)
        {
            var allCartiere = context.Cartier;
            var apartamentCartiere = new HashSet<int>(
            apartament.CartiereApartament.Select(c => c.CartierID)); //
            AssignedCartierDataList = new List<AssignedCartierData>();
            foreach (var car in allCartiere)
            {
                AssignedCartierDataList.Add(new AssignedCartierData
                {
                    CartierID = car.ID,
                    Nume = car.NumeCartier,
                    Assigned = apartamentCartiere.Contains(car.ID)
                });
            }
        }
        public void UpdateCartiereApartament(Istrate_Alexandra_ProiectContext context,
        string[] selectedCartiere, Apartament apartamentToUpdate)
        {
            if (selectedCartiere == null)
            {
                apartamentToUpdate.CartiereApartament = new List<CartierApartament>();
                return;
            }
            var selectedCartiereHS = new HashSet<string>(selectedCartiere);
            var apartamentCartiere = new HashSet<int>
            (apartamentToUpdate.CartiereApartament.Select(c => c.Cartier.ID));
            foreach (var car in context.Cartier)
            {
                if (selectedCartiereHS.Contains(car.ID.ToString()))
                {
                    if (!apartamentCartiere.Contains(car.ID))
                    {
                        apartamentToUpdate.CartiereApartament.Add(
                        new CartierApartament
                        {
                            ApartamentID = apartamentToUpdate.ID,
                            CartierID = car.ID
                        });
                    }
                }
                else
                {
                    if (apartamentCartiere.Contains(car.ID))
                    {
                        CartierApartament courseToRemove
                        = apartamentToUpdate
                        .CartiereApartament
                       .SingleOrDefault(i => i.CartierID == car.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
