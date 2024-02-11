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

        public DbSet<Pizza> Pizza { get; set; }
        public DbSet<Ingredients> Ingredients { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<PizzaOrders> PizzaOrders { get; set; }
        public DbSet<IngredientsOrders> IngredientsOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // MM for pizza and orders
            modelBuilder.Entity<PizzaOrders>()
                .HasKey(sc => new { sc.PizzaId, sc.OrdersId });

            modelBuilder.Entity<PizzaOrders>()
                .HasOne(sc => sc.Pizza)
                .WithMany(s => s.PizzaOrders)
                .HasForeignKey(sc => sc.PizzaId);

            modelBuilder.Entity<PizzaOrders>()
                .HasOne(sc => sc.Orders)
                .WithMany(c => c.PizzaOrders)
                .HasForeignKey(sc => sc.OrdersId);

            // MM for ingredients and orders
            modelBuilder.Entity<IngredientsOrders>()
                .HasKey(sc => new { sc.IngredientsId, sc.OrdersId });

            modelBuilder.Entity<IngredientsOrders>()
                .HasOne(sc => sc.Ingredients)
                .WithMany(s => s.IngredientsOrders)
                .HasForeignKey(sc => sc.OrdersId);

            modelBuilder.Entity<IngredientsOrders>()
                .HasOne(sc => sc.Orders)
                .WithMany(c => c.IngredientsOrders)
                .HasForeignKey(sc => sc.OrdersId);
            
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

            modelBuilder.Entity<Pizza>().HasData(
                new Pizza { id = 1, name = "Pizza Napoli" },
                new Pizza { id = 2, name = "Pizza Roma" }
            );
        }

    }

}
