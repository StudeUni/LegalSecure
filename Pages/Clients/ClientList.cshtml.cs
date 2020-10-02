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
    public class ClientListIndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public ClientListIndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IList<Client> Client { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public async Task OnGetAsync()
        {
            var clients = from m in _db.Client
                          select m; 

            if(!string.IsNullOrEmpty(SearchString))
            {
                clients = clients.Where(s => s.FirstName.Contains(SearchString) || s.LastName.Contains(SearchString));
            }



            Client = await clients.ToListAsync();


        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var client = await _db.Client.FindAsync(id);

            if (client == null)
            {
                return NotFound();

            }
            _db.Client.Remove(client);

            await _db.SaveChangesAsync();

            return RedirectToPage("/Clients/ClientList");
        }
    }
}
