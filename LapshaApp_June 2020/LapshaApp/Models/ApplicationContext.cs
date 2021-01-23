using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using LapshaApp.Models;

namespace LapshaApp
{
    public class ApplicationContext : DbContext
    {
        private string _dbPath;
        public DbSet<Product> Products { get; set; }
        public DbSet<Day> Days { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<ShopList> ShopLists { get; set; }
        public DbSet<ProductDay> ProductDays { get; set; } 
        public DbSet<ProductRecipes> ProductRecipes { get; set; }
        public DbSet<RecipeDays> RecipeDays { get; set; }

        public ApplicationContext(string dbPath) : base()
        {
            _dbPath = dbPath;
            Database.EnsureCreated();
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_dbPath}");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region ProductDay ModelBuilder

            modelBuilder.Entity<ProductDay>()
                .HasKey(t => new { t.productId, t.dayId });

            modelBuilder.Entity<ProductDay>()
                .HasOne(sc => sc.Product)
                .WithMany(s => s.ProductDays)
                .HasForeignKey(sc => sc.productId);

            modelBuilder.Entity<ProductDay>()
                .HasOne(sc => sc.Day)
                .WithMany(c => c.ProductDays)
                .HasForeignKey(sc => sc.dayId);

            modelBuilder.Entity<ProductDay>()
                .Property(w => w.weight);

            #endregion

            #region ProductRecipes ModelBuilder

            modelBuilder.Entity<ProductRecipes>()
                .HasKey(t => new { t.productId, t.recipeId });

            modelBuilder.Entity<ProductRecipes>()
                .HasOne(sc => sc.Product)
                .WithMany(s => s.ProductRecipes)
                .HasForeignKey(sc => sc.productId);

            modelBuilder.Entity<ProductRecipes>()
                .HasOne(sc => sc.Recipe)
                .WithMany(s => s.ProductRecipes)
                .HasForeignKey(sc => sc.recipeId);

            modelBuilder.Entity<ProductRecipes>()
                .Property(w => w.weight);

            #endregion

            #region RecipeDays ModelBuilder



            #endregion
        }
        public async void FirstStartFilling(string dbPath)
        {
            try
            {

                List<Product> productList = new List<Product>();
                List<Day> days = new List<Day>();                

                #region Products to Add

                productList.Add(new Product { productName = "Яйцо куриное", prot = 12.7, fat = 10.9, carb = 0.7, calorie = 157 });
                productList.Add(new Product { productName = "Огурец", prot = 0.8, fat = 0.1, carb = 2.8, calorie = 15 });
                productList.Add(new Product { productName = "Кабачок", prot = 0.6, fat = 0.3, carb = 4.6, calorie = 24 });
                productList.Add(new Product { productName = "Помидор", prot = 1.1, fat = 0.2, carb = 3.7, calorie = 20 });
                productList.Add(new Product { productName = "Свинина", prot = 16, fat = 21.6, carb = 0, calorie = 259 });
                productList.Add(new Product { productName = "Говядина", prot = 18.9, fat = 12.4, carb = 0, calorie = 187 });
                productList.Add(new Product { productName = "Банан", prot = 1.5, fat = 0.2, carb = 21.8, calorie = 95 });
                productList.Add(new Product { productName = "Яблоко", prot = 0.4, fat = 0.4, carb = 9.8, calorie = 47 });
                productList.Add(new Product { productName = "Курица", prot = 16, fat = 14, carb = 0, calorie = 190 });
                productList.Add(new Product { productName = "Молоко", prot = 3.2, fat = 3.6, carb = 4.8, calorie = 64 });

                #endregion

                #region Days to Add

                days.Add(new Day { dayName = "Monday", totalProt = 0, totalFat = 0, totalCarb = 0, totalCalorie = 0 });
                days.Add(new Day { dayName = "Tuesday", totalProt = 0, totalFat = 0, totalCarb = 0, totalCalorie = 0 });
                days.Add(new Day { dayName = "Wednesday", totalProt = 0, totalFat = 0, totalCarb = 0, totalCalorie = 0 });
                days.Add(new Day { dayName = "Thursday", totalProt = 0, totalFat = 0, totalCarb = 0, totalCalorie = 0 });
                days.Add(new Day { dayName = "Friday", totalProt = 0, totalFat = 0, totalCarb = 0, totalCalorie = 0 });
                days.Add(new Day { dayName = "Saturday", totalProt = 0, totalFat = 0, totalCarb = 0, totalCalorie = 0 });
                days.Add(new Day { dayName = "Sunday", totalProt = 0, totalFat = 0, totalCarb = 0, totalCalorie = 0 });

                #endregion                
                
                Products.AddRange(productList);
                Days.AddRange(days);

                await SaveChangesAsync();
            }
            catch (Exception e)
            {

            }
        }
    }
}