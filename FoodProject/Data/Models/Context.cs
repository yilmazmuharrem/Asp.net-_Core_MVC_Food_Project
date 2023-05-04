using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodProject.Data.Models
{
    public class Context:DbContext
    {


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
    
              optionsBuilder.UseSqlServer("Server=DESKTOP-TRILS1N;database=DbFood2; integrated security=true;TrustServerCertificate=True");

        }


        public DbSet<Food> Foods { get; set; }

        public DbSet<Category> Categories { get; set; }


        public DbSet<Admin> Admins { get; set; }
    }
}
