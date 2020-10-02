using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LegalSecure.Data;
using LegalSecure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LegalSecure.Pages.Activities
{
    public class ActivitiesListModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public ActivitiesListModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IList<Client> CaseVM { get; set; }

    }
}
