using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


namespace LapshaApp
{
    public partial class ApplicationContext : DbContext
    {
        private string _databasePath;
        public virtual DbSet<Day> Days { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductDay> ProductDays { get; set; }
        public virtual DbSet<ProductRecipe> ProductRecipes { get; set; }
        public virtual DbSet<Recipe> Recipes { get; set; }
        public virtual DbSet<ShopList> ShopLists { get; set; }

        public ApplicationContext(string databasePath)
        {
            _databasePath = databasePath;
        }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_databasePath}");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Day>(entity =>
            {
                entity.HasIndex(e => e.DayId, "IX_Days_DayId")
                    .IsUnique();

                entity.Property(e => e.Calorie).HasColumnName("calorie");

                entity.Property(e => e.Carb).HasColumnName("carb");

                entity.Property(e => e.Fat).HasColumnName("fat");

                entity.Property(e => e.Prot).HasColumnName("prot");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasIndex(e => e.ProductId, "IX_Products_ProductId")
                    .IsUnique();

                entity.HasIndex(e => e.ProductName, "IX_Products_ProductName")
                    .IsUnique();

                entity.HasIndex(e => e.ProductName, "ProductIndices");

                entity.Property(e => e.Calorie).HasColumnName("calorie");

                entity.Property(e => e.Carb).HasColumnName("carb");

                entity.Property(e => e.Category).HasColumnName("category");

                entity.Property(e => e.Fat).HasColumnName("fat");

                entity.Property(e => e.Prot).HasColumnName("prot");
            });

            modelBuilder.Entity<ProductDay>(entity =>
            {
                entity.HasIndex(e => e.Id, "IX_ProductDays_Id")
                    .IsUnique();

                entity.Property(e => e.Weight).HasColumnName("weight");

                entity.HasOne(d => d.Day)
                    .WithMany(p => p.ProductDays)
                    .HasForeignKey(d => d.DayId);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductDays)
                    .HasForeignKey(d => d.ProductId);
            });

            modelBuilder.Entity<ProductRecipe>(entity =>
            {
                entity.HasIndex(e => e.Id, "IX_ProductRecipes_Id")
                    .IsUnique();

                entity.Property(e => e.Weight).HasColumnName("weight");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductRecipes)
                    .HasForeignKey(d => d.ProductId);

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.ProductRecipes)
                    .HasForeignKey(d => d.RecipeId);
            });

            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.HasIndex(e => e.ProductId, "IX_Recipes_ProductId")
                    .IsUnique();

                entity.HasIndex(e => e.RecipeId, "IX_Recipes_RecipeId")
                    .IsUnique();

                entity.HasOne(d => d.Product)
                    .WithOne(p => p.Recipe)
                    .HasForeignKey<Recipe>(d => d.ProductId);
            });

            modelBuilder.Entity<ShopList>(entity =>
            {
                entity.ToTable("ShopList");

                entity.HasIndex(e => e.Id, "IX_ShopList_Id")
                    .IsUnique();

                entity.Property(e => e.BuyCheck).HasColumnName("buyCheck");

                entity.Property(e => e.Weight).HasColumnName("weight");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ShopLists)
                    .HasForeignKey(d => d.ProductId);
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
