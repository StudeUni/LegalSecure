using System.Threading.Tasks;
using LegalSecure.Data;
using LegalSecure.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LegalSecure.Pages.Clients
{
    public class ClientModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public ClientModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public Client Client { get; set; }
        public async Task OnGetAsync(int id)
        {
            Client = await _db.Client.FindAsync(id);
        }

    }
}
