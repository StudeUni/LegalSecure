using System.Threading.Tasks;
using LegalSecure.Data;
using LegalSecure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LegalSecure.Pages.Clients
{
    public class ClientEditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public ClientEditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Client Client { get; set; }
        public async Task OnGetAsync(int id)
        {
            Client = await _db.Client.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                var entry = _db.Add(new Client());
                entry.CurrentValues.SetValues(Client);
                await _db.SaveChangesAsync();
                return RedirectToPage("/Error");
            }
        }
    }
}
