using System.Threading.Tasks;
using LegalSecure.Data;
using LegalSecure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

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

        public async Task OnGet(int id)
        {
            Client = await _db.Client.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var clientFromDB = await _db.Client.FindAsync(Client.ID);
                clientFromDB.FirstName = Client.FirstName;
                clientFromDB.LastName = Client.LastName;
                clientFromDB.BirthDate = Client.BirthDate;
                clientFromDB.ContactPhone = Client.ContactPhone;
                clientFromDB.EmailAddress = Client.EmailAddress;
                clientFromDB.StreetAddress = Client.StreetAddress;
                clientFromDB.PostCode = Client.PostCode;
                clientFromDB.Cases = Client.Cases;

                await _db.SaveChangesAsync();

                return RedirectToPage("/Clients/ClientList");
            }
            return RedirectToPage("/Error");
        }
    }
}
