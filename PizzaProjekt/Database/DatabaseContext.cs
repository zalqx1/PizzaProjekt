using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaProjekt.Models;
using Microsoft.EntityFrameworkCore;

namespace PizzaProjekt.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<Ingredients> Ingredients { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Pizza> Pizza { get; set; }
        public DbSet<OrdersPizza> OrdersPizza { get; set; }
        public DbSet<PizzaIngredients> PizzaIngredients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // MM for ingredients and pizza
            modelBuilder.Entity<PizzaIngredients>()
                .HasKey(pi => new { pi.PizzaId, pi.IngredientsId });

            modelBuilder.Entity<PizzaIngredients>()
                .HasOne(pi => pi.Pizza)
                .WithMany(p => p.PizzaIngredients)
                .HasForeignKey(pi => pi.PizzaId);

            modelBuilder.Entity<PizzaIngredients>()
                .HasOne(pi => pi.Ingredients)
                .WithMany(i => i.PizzaIngredients)
                .HasForeignKey(pi => pi.IngredientsId);

            // MM for orders and pizza
            modelBuilder.Entity<OrdersPizza>()
                .HasKey(pi => new { pi.OrdersId, pi.PizzaId });

            modelBuilder.Entity<OrdersPizza>()
                .HasOne(pi => pi.Orders)
                .WithMany(p => p.OrdersPizza)
                .HasForeignKey(pi => pi.OrdersId);

            modelBuilder.Entity<OrdersPizza>()
                .HasOne(pi => pi.Pizza)
                .WithMany(i => i.OrdersPizza)
                .HasForeignKey(pi => pi.PizzaId);

            SeedData(modelBuilder);
        }


        public void SeedData(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Ingredients>().HasData(
                new Ingredients { id = 1, name = "Salami", gruppe = "Meats" },
                new Ingredients { id = 2, name = "Sucuk", gruppe = "Meats" },
                new Ingredients { id = 3, name = "Schinken", gruppe = "Meats" },
                new Ingredients { id = 4, name = "Pepperoni", gruppe = "Vegetables" },
                new Ingredients { id = 5, name = "Tomaten", gruppe = "Vegetables" },
                new Ingredients { id = 6, name = "Oliven", gruppe = "Vegetables" },
                new Ingredients { id = 7, name = "Mozzarella", gruppe = "Cheese" },
                new Ingredients { id = 8, name = "Schafskäse", gruppe = "Cheese" },
                new Ingredients { id = 9, name = "Parmesan", gruppe = "Cheese" }
            );
        }

    }

}
