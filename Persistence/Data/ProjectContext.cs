using DomainDrivenDesign.Domain.AggregationModels.DishAggregation;
using DomainDrivenDesign.Domain.AggregationModels.OrderAggregation;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace DomainDrivenDesign.Data
{
    public partial class ProjectContext: DbContext
    {
        private readonly IConfiguration _configuration;
        public ProjectContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public virtual DbSet<Dish> Dishes { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(_configuration.GetConnectionString("ProjectContext"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dish>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                   .HasMaxLength(500)
                   .IsUnicode(false);

                entity.Property(e => e.Price);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.TotalPrice);

                entity.HasOne(d => d.Table)
                  .WithMany(p => p.Orders)
                  .HasForeignKey(d => d.TableId)
                  .HasConstraintName("FK_Table_Order");

                

            });

            modelBuilder.Entity<Table>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Number);
                entity.Property(e => e.Capacity);
                entity.Property(e => e.IsAvailable);
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Quantity);

                entity.HasOne(d => d.Order)
                 .WithMany(p => p.Items)
                 .HasForeignKey(d => d.OrderId)
                 .HasConstraintName("FK_OrderItem_Order");

                entity.HasOne(d => d.Dish)
                .WithMany(p => p.Items)
                .HasForeignKey(d => d.DishId)
                .HasConstraintName("FK_OrderItem_Dish");
            });

            modelBuilder.Entity<Ingredient>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name)
                 .HasMaxLength(500)
                 .IsUnicode(false);

                entity.Property(e => e.Price);

                entity.HasOne(d => d.Dish)
               .WithMany(p => p.Ingredients)
               .HasForeignKey(d => d.DishId)
               .HasConstraintName("FK_Ingredient_Dish");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
