using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LegalSecure.Data;
using LegalSecure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LegalSecure.Pages.Solicitors
{
    public class SolicitorListModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public SolicitorListModel(ApplicationDbContext db)
        {
            this._db = db;
        }

        public IList<Solicitor> Solicitor { get; set; }
        public async Task OnGetAsync()
        {
            Solicitor = await _db.Solicitor.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var solicitor = await _db.Solicitor.FindAsync(id);
            if (solicitor == null)
            {
                return NotFound();

            }
            _db.Solicitor.Remove(solicitor);
            await _db.SaveChangesAsync();

            return RedirectToPage("/Solicitors/SolicitorList");
        }
    }
}
