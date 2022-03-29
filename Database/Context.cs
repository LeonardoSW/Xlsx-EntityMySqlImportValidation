using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
using ValidaçãoPrecoPlanilhaHub2b.Models;

namespace ValidaçãoPrecoPlanilhaHub2b.Database
{
    public class Context : DbContext
    {
        public DbSet<ProductPrice>? product { get; set; }
        
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Str Connection", ServerVersion.Parse("8.0.25-mysql"));
        }
    }
}
