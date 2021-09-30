﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TeendokLista.Data.DAL;

namespace TeendokLista.Data.Migrations
{
    [DbContext(typeof(TeendokContext))]
    [Migration("20210930222914_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.10");

            modelBuilder.Entity("TeendokLista.Data.Models.Feladat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cim")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("FelhasznaloId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LetrehozasDatum")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Szoveg")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Teljesitve")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.HasIndex("FelhasznaloId");

                    b.ToTable("Feladatok");
                });

            modelBuilder.Entity("TeendokLista.Data.Models.Felhasznalo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Felhasznalonev")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Jelszo")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("Felhasznalonev")
                        .IsUnique();

                    b.ToTable("Felhasznalok");
                });

            modelBuilder.Entity("TeendokLista.Data.Models.Feladat", b =>
                {
                    b.HasOne("TeendokLista.Data.Models.Felhasznalo", "Felhasznalo")
                        .WithMany("Feladatok")
                        .HasForeignKey("FelhasznaloId");

                    b.Navigation("Felhasznalo");
                });

            modelBuilder.Entity("TeendokLista.Data.Models.Felhasznalo", b =>
                {
                    b.Navigation("Feladatok");
                });
#pragma warning restore 612, 618
        }
    }
}
