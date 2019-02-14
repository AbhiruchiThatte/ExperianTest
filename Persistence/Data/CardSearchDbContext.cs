using ExperianTest.ApplicationCore.Entities;
using ExperianTest.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;

namespace ExperianTest.Persistence.Data
{
    public class CardSearchDbContext : DbContext
    {
        public CardSearchDbContext(DbContextOptions<CardSearchDbContext> options)
                            : base(options)
        { }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Customer>().Property(c => c.AnnualIncome).HasPrecision(18, 2);

        //    base.OnModelCreating(modelBuilder);
        //}

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductRule> ProductRules { get; set; }
        public DbSet<Request> Requests { get; set; }
    }
}
