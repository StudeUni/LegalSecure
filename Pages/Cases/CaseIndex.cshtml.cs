using LegalSecure.Data;
using LegalSecure.Pages.Clients;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using LegalSecure.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace LegalSecure.Pages.Cases
{
    public class CaseIndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public CaseIndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IList<CourseViewModel> CourseVM { get; set; }

        public async Task OnGetAsync()
        {
            CourseVM = await _db.Case
                    .Select(p => new CourseViewModel
                    {
                        ClientID = p.ClientID,
                        FirstName = p.Client.FirstName,
                        LastName = p.Client.LastName,
                        CaseDescription = p.Description
                    }).ToListAsync();
        }
    }
}
