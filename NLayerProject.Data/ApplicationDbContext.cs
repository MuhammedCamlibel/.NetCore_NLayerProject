using Microsoft.EntityFrameworkCore;
using NLayerProject.Core.Models;
using NLayerProject.Data.Configurations;
using NLayerProject.Data.Seeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Person> Persons { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // veritabanındaki tabloların oluşmadan önce çalışacak metot 
            // tabloların özellikleri burada belirtebiliriz

            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());

            modelBuilder.ApplyConfiguration(new CategorySeed(new int[] { 1, 2 }));
            modelBuilder.ApplyConfiguration(new ProductSeed(new int[] { 1, 2 }));


            modelBuilder.Entity<Person>().HasKey(p => p.Id);
            modelBuilder.Entity<Person>().Property(p => p.Id).UseIdentityColumn();
            modelBuilder.Entity<Person>().Property(p => p.Name).HasMaxLength(50);
            modelBuilder.Entity<Person>().Property(p => p.SurName).HasMaxLength(50);


        }
    }
}
