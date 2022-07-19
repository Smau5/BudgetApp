﻿// <auto-generated />
using System;
using BudgetApp.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BudgetApp.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BudgetApp.Core.BudgetAggregate.Budget", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("AvailableToAssign")
                        .HasPrecision(12, 2)
                        .HasColumnType("numeric(12,2)");

                    b.HasKey("Id");

                    b.ToTable("Budgets");
                });

            modelBuilder.Entity("BudgetApp.Core.BudgetAggregate.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Assigned")
                        .HasPrecision(12, 2)
                        .HasColumnType("numeric(12,2)");

                    b.Property<decimal>("AvailableToSpend")
                        .HasPrecision(12, 2)
                        .HasColumnType("numeric(12,2)");

                    b.Property<Guid?>("BudgetId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BudgetId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("BudgetApp.Core.TransactionAggregate.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("Amount")
                        .HasPrecision(12, 2)
                        .HasColumnType("numeric(12,2)");

                    b.Property<Guid>("BudgetId")
                        .HasColumnType("uuid");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("BudgetId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("BudgetApp.Core.BudgetAggregate.Category", b =>
                {
                    b.HasOne("BudgetApp.Core.BudgetAggregate.Budget", null)
                        .WithMany("Categories")
                        .HasForeignKey("BudgetId");
                });

            modelBuilder.Entity("BudgetApp.Core.TransactionAggregate.Transaction", b =>
                {
                    b.HasOne("BudgetApp.Core.BudgetAggregate.Budget", null)
                        .WithMany()
                        .HasForeignKey("BudgetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BudgetApp.Core.BudgetAggregate.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoryId");
                });

            modelBuilder.Entity("BudgetApp.Core.BudgetAggregate.Budget", b =>
                {
                    b.Navigation("Categories");
                });
#pragma warning restore 612, 618
        }
    }
}
