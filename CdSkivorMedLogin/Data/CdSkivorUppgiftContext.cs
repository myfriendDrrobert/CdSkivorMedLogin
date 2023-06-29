using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CdSkivorUppgift.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CdSkivorUppgift.Data
{
    public class CdSkivorUppgiftContext : IdentityDbContext
    {
        public CdSkivorUppgiftContext (DbContextOptions<CdSkivorUppgiftContext> options)
            : base(options)
        {
        }
       
        public DbSet<Record> Records { get; set; }

        public DbSet<Song> Songs { get; set; }
    }
}
