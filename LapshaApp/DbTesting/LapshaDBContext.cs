using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DbTesting
{
    public partial class LapshaDBContext : DbContext
    {
        public LapshaDBContext()
        {
        }

        public LapshaDBContext(DbContextOptions<LapshaDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Day> Days { get; set; }
        public virtual DbSet<Meal> Meals { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductMeal> ProductMeals { get; set; }
        public virtual DbSet<ProductRecipe> ProductRecipes { get; set; }
        public virtual DbSet<Recipe> Recipes { get; set; }
        public virtual DbSet<ShopList> ShopLists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Day>(entity =>
            {
                entity.HasIndex(e => e.DayId, "IX_Days_DayId")
                    .IsUnique();

                entity.Property(e => e.Calorie).HasColumnName("calorie");

                entity.Property(e => e.Carb).HasColumnName("carb");

                entity.Property(e => e.DayName).IsRequired();

                entity.Property(e => e.Fat).HasColumnName("fat");

                entity.Property(e => e.Prot).HasColumnName("prot");
            });

            modelBuilder.Entity<Meal>(entity =>
            {
                entity.HasIndex(e => e.MealId, "IX_Meals_MealId")
                    .IsUnique();

                entity.HasOne(d => d.Day)
                    .WithMany(p => p.Meals)
                    .HasForeignKey(d => d.DayId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasIndex(e => e.ProductId, "IX_Products_ProductId")
                    .IsUnique();

                entity.HasIndex(e => e.ProductName, "IX_Products_ProductName")
                    .IsUnique();

                entity.HasIndex(e => e.ProductName, "ProductIndices");

                entity.Property(e => e.ProductCategory).IsRequired();

                entity.Property(e => e.ProductName).IsRequired();
            });

            modelBuilder.Entity<ProductMeal>(entity =>
            {
                entity.HasIndex(e => e.Id, "IX_ProductMeals_Id")
                    .IsUnique();

                entity.HasOne(d => d.Meal)
                    .WithMany(p => p.ProductMeals)
                    .HasForeignKey(d => d.MealId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductMeals)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<ProductRecipe>(entity =>
            {
                entity.HasIndex(e => e.Id, "IX_ProductRecipes_Id")
                    .IsUnique();

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductRecipes)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.ProductRecipes)
                    .HasForeignKey(d => d.RecipeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.HasIndex(e => e.ProductId, "IX_Recipes_ProductId")
                    .IsUnique();

                entity.HasIndex(e => e.RecipeId, "IX_Recipes_RecipeId")
                    .IsUnique();

                entity.HasOne(d => d.Product)
                    .WithOne(p => p.Recipe)
                    .HasForeignKey<Recipe>(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<ShopList>(entity =>
            {
                entity.ToTable("ShopList");

                entity.HasIndex(e => e.Id, "IX_ShopList_Id")
                    .IsUnique();

                entity.Property(e => e.BuyCheck).HasColumnName("buyCheck");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ShopLists)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
