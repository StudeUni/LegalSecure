using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LegalSecure.Data;
using LegalSecure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LegalSecure.Pages.Clients
{
    public class ClientCreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public ClientCreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Client Client { get; set; }


        public void OnGet()
        {

        }

        //Needs to be checked 
        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                await _db.Client.AddAsync(Client);
                await _db.SaveChangesAsync();

                return RedirectToPage("/Clients/ClientList");
            }
            else
            {
                return RedirectToPage("/Error");
            }
        }
    }
}
