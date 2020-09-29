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

        public IList<Client> Client { get; set; }

        public async Task OnGetAsync()
        {
            Client = await _db.Client.ToListAsync();
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
