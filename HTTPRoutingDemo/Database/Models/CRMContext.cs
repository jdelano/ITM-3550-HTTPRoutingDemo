using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace HTTPRoutingDemo.Database.Models
{
    public class CRMContext : DbContext
    {
        public CRMContext()
        {
        }

        public CRMContext(DbContextOptions<CRMContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseInMemoryDatabase("CRMDemo");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(customer => customer.HasKey(e => e.CustomerId));
            modelBuilder.Entity<Customer>().HasData(new Customer { CustomerId = 1, FirstName = "Bob", LastName = "Smith", Balance = 500.00 });
            modelBuilder.Entity<Customer>().HasData(new Customer { CustomerId = 2, FirstName = "Jim", LastName = "Jones", Balance = 250.00 });
            modelBuilder.Entity<Customer>().HasData(new Customer { CustomerId = 3, FirstName = "Jon", LastName = "Donne", Balance = 126.98 });
            modelBuilder.Entity<Customer>().HasData(new Customer { CustomerId = 4, FirstName = "Ken", LastName = "Towns", Balance = 548.32 });
            modelBuilder.Entity<Customer>().HasData(new Customer { CustomerId = 5, FirstName = "Tom", LastName = "Thumb", Balance = 974.26 });
        }
    }
}

