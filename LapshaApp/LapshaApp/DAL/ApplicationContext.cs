using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


namespace LapshaApp
{
    public partial class ApplicationContext : DbContext
    {
        private string _databasePath;
        public DbSet<Day> Days { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductMeal> ProductMeals { get; set; }
        public DbSet<ProductRecipe> ProductRecipes { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<ShopList> ShopLists { get; set; }

        public ApplicationContext(string databasePath)
        {
            _databasePath = databasePath;
            Database.EnsureCreated();
        }        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_databasePath}");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Recipes ModelBuilder

            modelBuilder.Entity<Recipe>()
                .HasKey(r => new { r.RecipeId });

            modelBuilder.Entity<Recipe>()
                .HasOne(r => r.Product)
                .WithOne(r => r.Recipe);

            #endregion

            #region ShopList ModelBuilder

            modelBuilder.Entity<ShopList>()
                .HasKey(r => new { r.Id });

            modelBuilder.Entity<ShopList>()
                .HasOne(r => r.Product)
                .WithOne(r => r.ShopList);

            #endregion

            #region Meals ModelBuilder

            modelBuilder.Entity<Meal>()
                .HasOne(m => m.Day)
                .WithMany(m => m.Meals);

            #endregion

            #region ProductMeals ModelBuilder

            modelBuilder.Entity<ProductMeal>()
                .HasKey(pm => new { pm.ProductId, pm.MealId });

            modelBuilder.Entity<ProductMeal>()
                .HasOne(pm => pm.Product)
                .WithMany(pm => pm.ProductMeals)
                .HasForeignKey(pm => pm.ProductId);

            modelBuilder.Entity<ProductMeal>()
                .HasOne(pm => pm.Meal)
                .WithMany(pm => pm.ProductMeals)
                .HasForeignKey(pm => pm.MealId);

            modelBuilder.Entity<ProductMeal>()
                .Property(pm => pm.ProductWeight);

            #endregion

            #region ProductRecipes ModelBuilder

            modelBuilder.Entity<ProductRecipe>()
                .HasKey(pr => new { pr.ProductId, pr.RecipeId });

            modelBuilder.Entity<ProductRecipe>()
                .HasOne(pr => pr.Product)
                .WithMany(pr => pr.ProductRecipes)
                .HasForeignKey(pr => pr.ProductId);

            modelBuilder.Entity<ProductRecipe>()
                .HasOne(pr => pr.Recipe)
                .WithMany(pr => pr.ProductRecipes)
                .HasForeignKey(pr => pr.RecipeId);

            modelBuilder.Entity<ProductRecipe>()
                .Property(pr => pr.ProductWeight);

            #endregion
        }
    }
}
