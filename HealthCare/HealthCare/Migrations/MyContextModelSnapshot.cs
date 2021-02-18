﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using HealthCare.Controllers;

namespace HealthCare.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("HealthCare.Models.Ljekar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sifra")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Titula")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Ljekari");
                });

            modelBuilder.Entity("HealthCare.Models.Nalaz", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DatumVrijeme")
                        .HasColumnType("datetime2");

                    b.Property<string>("NalazOpis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PacijentPrijemID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("PacijentPrijemID");

                    b.ToTable("Nalazi");
                });

            modelBuilder.Entity("HealthCare.Models.Pacijent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Adresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BrojTelefona")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DatumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SpolID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SpolID");

                    b.ToTable("Pacijenti");
                });

            modelBuilder.Entity("HealthCare.Models.PacijentPrijem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DatumVrijeme")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsHitno")
                        .HasColumnType("bit");

                    b.Property<bool>("IsOtkazano")
                        .HasColumnType("bit");

                    b.Property<int>("LjekarID")
                        .HasColumnType("int");

                    b.Property<int>("PacijentID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LjekarID");

                    b.HasIndex("PacijentID");

                    b.ToTable("PacijentPrijemi");
                });

            modelBuilder.Entity("HealthCare.Models.Spol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Spol");
                });

            modelBuilder.Entity("HealthCare.Models.Nalaz", b =>
                {
                    b.HasOne("HealthCare.Models.PacijentPrijem", "PacijentPrijem")
                        .WithMany()
                        .HasForeignKey("PacijentPrijemID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PacijentPrijem");
                });

            modelBuilder.Entity("HealthCare.Models.Pacijent", b =>
                {
                    b.HasOne("HealthCare.Models.Spol", "Spol")
                        .WithMany()
                        .HasForeignKey("SpolID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Spol");
                });

            modelBuilder.Entity("HealthCare.Models.PacijentPrijem", b =>
                {
                    b.HasOne("HealthCare.Models.Ljekar", "Ljekar")
                        .WithMany()
                        .HasForeignKey("LjekarID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HealthCare.Models.Pacijent", "Pacijent")
                        .WithMany()
                        .HasForeignKey("PacijentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ljekar");

                    b.Navigation("Pacijent");
                });
#pragma warning restore 612, 618
        }
    }
}
