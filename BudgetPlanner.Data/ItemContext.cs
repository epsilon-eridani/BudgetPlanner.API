using BudgetPlanner.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetPlanner.Data
{
    public class ItemContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<ParentCategory> ParentCategories { get; set; }
        public DbSet<CustomCategory> CustomCategories { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>()
                .HasOne(i => i.CustomCategory)
                .WithMany(c => c.Items)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Item>()
                .HasOne(i => i.ParentCategory)
                .WithMany(c => c.Items)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CustomCategory>()
                .HasOne(i => i.ParentCategory)
                .WithMany(c => c.CustomCategories)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=DESKTOP-I558N3K;Initial Catalog=BudgetPlanner;Integrated Security=True");
        }
    }
}
