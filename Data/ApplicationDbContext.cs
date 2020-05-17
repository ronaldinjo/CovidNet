using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CovidNet.Models;

namespace CovidNet.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
           
        }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        public DbSet<Patient> Patient { get; set; }

    

        public DbSet<State> State { get; set; }

        public DbSet<UserProfile> UserProfile { get; set; }
        public DbSet<NumberSequence> NumberSequence { get; set; }
    }
}
