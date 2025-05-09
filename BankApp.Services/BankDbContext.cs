using System;
using System.Data.Entity;
using System.Security.Principal;
using BankApp.Models;

namespace BankApp.Services
{
    public class BankDbContext : DbContext
    { public BankDbContext() : base("name=BankDb") { }

        // DbSet properties
    public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        // Optional: Fluent API for configuring model relationships
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Example: unique constraint on AccountNumber (not enforced by EF6 automatically, must be done in DB or logic)
            modelBuilder.Entity<Account>()
                .Property(a => a.AccountNumber)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}