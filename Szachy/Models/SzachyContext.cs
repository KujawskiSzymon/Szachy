using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Szachy.Models
{
    public class SzachyContext : DbContext
    {
        
        public SzachyContext(DbContextOptions<SzachyContext> options)
            : base(options)
        {
        }

        public DbSet<Gracz> Gracz { get; set; }
        public DbSet<Klub> Klub { get; set; }
        public DbSet<Mecz> Mecz { get; set; }
    }
}

