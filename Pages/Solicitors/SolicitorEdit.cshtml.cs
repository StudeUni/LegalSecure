using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LegalSecure.Data;
using LegalSecure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LegalSecure.Pages.Solicitors
{
    public class SolicitorEditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public SolicitorEditModel(ApplicationDbContext db)
        {
            this._db = db;
        }

        [BindProperty]
        public Solicitor Solicitor { get; set; }

        public async Task OnGet(int id)
        {
            Solicitor = await _db.Solicitor.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var solicitorFromDB = await _db.Solicitor.FindAsync(Solicitor.ID);
                solicitorFromDB.FirstName = Solicitor.FirstName;
                solicitorFromDB.LastName = Solicitor.LastName;
                solicitorFromDB.BirthDate = Solicitor.BirthDate;
                solicitorFromDB.ContactPhone = Solicitor.ContactPhone;
                solicitorFromDB.EmailAddress = Solicitor.EmailAddress;
                solicitorFromDB.StreetAddress = Solicitor.StreetAddress;
                solicitorFromDB.PostCode = Solicitor.PostCode;
                solicitorFromDB.Activities = Solicitor.Activities;

                await _db.SaveChangesAsync();

                return RedirectToPage("/Solicitors/SolicitorList");
            }
            return RedirectToPage("/Error");
        }
    }
}
