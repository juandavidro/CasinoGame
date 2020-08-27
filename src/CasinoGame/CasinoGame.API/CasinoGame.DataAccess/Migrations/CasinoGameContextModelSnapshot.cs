﻿// <auto-generated />
using System;
using CasinoGame.DataAccess.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CasinoGame.DataAccess.Migrations
{
    [DbContext(typeof(CasinoGameContext))]
    partial class CasinoGameContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("CasinoGame.DataAccess.Entities.Bet", b =>
                {
                    b.Property<Guid>("BetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("BetColor")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("BetDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("BetNumber")
                        .HasColumnType("integer");

                    b.Property<int>("BetValue")
                        .HasColumnType("integer");

                    b.Property<Guid>("RouletteId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("UserId")
                        .IsRequired()
                        .HasColumnType("uuid");

                    b.HasKey("BetId");

                    b.HasIndex("RouletteId");

                    b.HasIndex("UserId");

                    b.ToTable("Bets");
                });

            modelBuilder.Entity("CasinoGame.DataAccess.Entities.Roulette", b =>
                {
                    b.Property<Guid>("RouletteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CloseDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("OpenDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("State")
                        .HasColumnType("text");

                    b.HasKey("RouletteId");

                    b.ToTable("Roulettes");
                });

            modelBuilder.Entity("CasinoGame.DataAccess.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Credit")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("LoginDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CasinoGame.DataAccess.Entities.Bet", b =>
                {
                    b.HasOne("CasinoGame.DataAccess.Entities.Roulette", "Roulette")
                        .WithMany("Bets")
                        .HasForeignKey("RouletteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CasinoGame.DataAccess.Entities.User", "User")
                        .WithMany("Bets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}