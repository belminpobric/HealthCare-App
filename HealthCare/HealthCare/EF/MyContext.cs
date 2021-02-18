using HealthCare.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.Controllers
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options)
            : base(options)
        {
        }
        public DbSet<Nalaz> Nalazi { get; set; }
        public DbSet<Ljekar> Ljekari { get; set; }
        public DbSet<Pacijent> Pacijenti { get; set; }
        public DbSet<Spol> Spol { get; set; }
        public DbSet<PacijentPrijem> PacijentPrijemi { get; set; }

    }
}
