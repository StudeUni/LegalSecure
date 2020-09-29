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
    public class SolicitorCreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public SolicitorCreateModel(ApplicationDbContext db)
        {
            this._db = db;
        }

        [BindProperty]
        public Solicitor Solicitor { get; set; }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _db.Solicitor.AddAsync(Solicitor);
                await _db.SaveChangesAsync();

                return RedirectToPage("/Solicitors/SolicitorList");
            }
            else
            {
                return RedirectToPage("/Error");
            }
        }
    }
}
