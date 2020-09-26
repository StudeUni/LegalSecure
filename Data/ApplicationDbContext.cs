using System;
using System.Collections.Generic;
using System.Text;
using LegalSecure.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LegalSecure.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Client { get; set; }
        public DbSet<Case> Case { get; set; }

        public DbSet<Solicitor> Solicitor { get; set; }

        public DbSet<Rate> Rate { get; set; }

        public DbSet<Activity> Activity { get; set; }
    }
}
