using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LegalSecure.Data;
using LegalSecure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LegalSecure.Pages.Clients
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Client> Client { get; set; }
        public async Task OnGetAsync()
        {
            Client = await _db.Client.ToListAsync();
        }
    }
}
