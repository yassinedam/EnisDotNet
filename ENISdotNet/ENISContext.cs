using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENISdotNet.Models;

namespace ENISdotNet
{
    public class ENISContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Departement> departements { get; set; }
        public DbSet<Section> sections { get; set; }
        public DbSet<DemandePFE> demandes { get; set; }
        public DbSet<Paper> papers { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsbuilder)
        {
            optionsbuilder.UseSqlServer(@"Server=DESKTOP-KN3QGLF\SQLEXPRESS;Database=NewENISDB01;Trusted_Connection=True;TrustServerCertificate=True");
        }
    }
}

