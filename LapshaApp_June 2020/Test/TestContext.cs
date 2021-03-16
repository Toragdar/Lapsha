using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public class TestContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Day> Days { get; set; }

        private string _dbPath;
        public TestContext(string dbPath) : base()
        {
            _dbPath = dbPath;
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductDay>()
            .HasKey(t => new { t.ProductId, t.DayId });

            modelBuilder.Entity<ProductDay>()
                .HasOne(sc => sc.Product)
                .WithMany(s => s.ProductDays)
                .HasForeignKey(sc => sc.ProductId);

            modelBuilder.Entity<ProductDay>()
                .HasOne(sc => sc.Day)
                .WithMany(c => c.ProductDays)
                .HasForeignKey(sc => sc.DayId);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_dbPath}");
        }
    }
}
