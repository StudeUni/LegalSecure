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
    public class ClientModel : PageModel
    {
        private ApplicationDbContext _db;

        public ClientModel(ApplicationDbContext db)
        {
            this._db = db;
        }

        public Solicitor Solicitor { get; set; }
        public async Task OnGetAsync(int id)
        {
            Solicitor = await _db.Solicitor.FindAsync(id);
        }
    }
}
