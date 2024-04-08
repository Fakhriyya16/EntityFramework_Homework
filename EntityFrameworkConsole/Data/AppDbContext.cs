using EntityFrameworkConsole.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkConsole.Data
{
    internal class AppDbContext : DbContext
    {
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=DESKTOP-RB3F59F\\MSSQLSERVER01;initial catalog=EntityFrameworkPB101;trusted_connection=true");
        }
    }
}
