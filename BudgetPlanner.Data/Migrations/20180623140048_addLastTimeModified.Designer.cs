﻿// <auto-generated />
using System;
using BudgetPlanner.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BudgetPlanner.Data.Migrations
{
    [DbContext(typeof(ItemContext))]
    [Migration("20180623140048_addLastTimeModified")]
    partial class addLastTimeModified
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BudgetPlanner.Domain.CustomCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<DateTime>("LastModified");

                    b.Property<string>("Name");

                    b.Property<int>("ParentCategoryId");

                    b.HasKey("ID");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("CustomCategories");
                });

            modelBuilder.Entity("BudgetPlanner.Domain.Item", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Amount");

                    b.Property<int?>("CustomCategoryID");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description");

                    b.Property<bool>("IsExpense");

                    b.Property<DateTime>("LastModified");

                    b.Property<string>("Name");

                    b.Property<int>("ParentCategoryId");

                    b.HasKey("ID");

                    b.HasIndex("CustomCategoryID");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("BudgetPlanner.Domain.ParentCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<DateTime>("LastModified");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("ParentCategories");
                });

            modelBuilder.Entity("BudgetPlanner.Domain.CustomCategory", b =>
                {
                    b.HasOne("BudgetPlanner.Domain.ParentCategory", "ParentCategory")
                        .WithMany("CustomCategories")
                        .HasForeignKey("ParentCategoryId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("BudgetPlanner.Domain.Item", b =>
                {
                    b.HasOne("BudgetPlanner.Domain.CustomCategory")
                        .WithMany("Items")
                        .HasForeignKey("CustomCategoryID");

                    b.HasOne("BudgetPlanner.Domain.ParentCategory", "ParentCategory")
                        .WithMany("Items")
                        .HasForeignKey("ParentCategoryId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}