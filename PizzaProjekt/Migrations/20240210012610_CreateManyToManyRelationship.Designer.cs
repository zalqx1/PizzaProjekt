﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PizzaProjekt.Database;

namespace PizzaProjekt.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240210012610_CreateManyToManyRelationship")]
    partial class CreateManyToManyRelationship
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("PizzaProjekt.Models.Ingredients", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("id");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("PizzaProjekt.Models.IngredientsOrders", b =>
                {
                    b.Property<int>("IngredientsId")
                        .HasColumnType("int");

                    b.Property<int>("OrdersId")
                        .HasColumnType("int");

                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.HasKey("IngredientsId", "OrdersId");

                    b.HasIndex("OrdersId");

                    b.ToTable("IngredientsOrders");
                });

            modelBuilder.Entity("PizzaProjekt.Models.Orders", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("city")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("nachname")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("number")
                        .HasColumnType("int");

                    b.Property<int>("postCode")
                        .HasColumnType("int");

                    b.Property<string>("street")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("PizzaProjekt.Models.Pizza", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("id");

                    b.ToTable("Pizza");
                });

            modelBuilder.Entity("PizzaProjekt.Models.PizzaOrders", b =>
                {
                    b.Property<int>("PizzaId")
                        .HasColumnType("int");

                    b.Property<int>("OrdersId")
                        .HasColumnType("int");

                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.HasKey("PizzaId", "OrdersId");

                    b.HasIndex("OrdersId");

                    b.ToTable("PizzaOrders");
                });

            modelBuilder.Entity("PizzaProjekt.Models.IngredientsOrders", b =>
                {
                    b.HasOne("PizzaProjekt.Models.Ingredients", "Ingredients")
                        .WithMany("IngredientsOrders")
                        .HasForeignKey("OrdersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzaProjekt.Models.Orders", "Orders")
                        .WithMany("IngredientsOrders")
                        .HasForeignKey("OrdersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PizzaProjekt.Models.PizzaOrders", b =>
                {
                    b.HasOne("PizzaProjekt.Models.Orders", "Orders")
                        .WithMany("PizzaOrders")
                        .HasForeignKey("OrdersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzaProjekt.Models.Pizza", "Pizza")
                        .WithMany("PizzaOrders")
                        .HasForeignKey("PizzaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
