﻿// <auto-generated />
using System;
using ENISdotNet;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ENISdotNet.Migrations
{
    [DbContext(typeof(ENISContext))]
    [Migration("20221114113221_777")]
    partial class _777
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DemandePFEUser", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("demandesId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "demandesId");

                    b.HasIndex("demandesId");

                    b.ToTable("DemandePFEUser");
                });

            modelBuilder.Entity("ENISdotNet.Models.DemandePFE", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("approved_at")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("demanded_at")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("demandes");
                });

            modelBuilder.Entity("ENISdotNet.Models.Departement", b =>
                {
                    b.Property<int>("DepartementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartementId"), 1L, 1);

                    b.Property<string>("spacialitée")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepartementId");

                    b.ToTable("departements");
                });

            modelBuilder.Entity("ENISdotNet.Models.Paper", b =>
                {
                    b.Property<int>("paperId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("paperId"), 1L, 1);

                    b.Property<string>("Staus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("approved_at")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("demanded_at")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("paperId");

                    b.ToTable("papers");
                });

            modelBuilder.Entity("ENISdotNet.Models.Section", b =>
                {
                    b.Property<int>("SectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SectionId"), 1L, 1);

                    b.Property<int>("DepartementId")
                        .HasColumnType("int");

                    b.Property<string>("Grade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("schoolYear")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sectionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SectionId");

                    b.HasIndex("DepartementId");

                    b.ToTable("sections");
                });

            modelBuilder.Entity("ENISdotNet.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<int?>("SectionId")
                        .HasColumnType("int");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("phoneNumber")
                        .HasColumnType("int");

                    b.Property<string>("role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("SectionId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PaperUser", b =>
                {
                    b.Property<int>("paperspaperId")
                        .HasColumnType("int");

                    b.Property<int>("usersUserId")
                        .HasColumnType("int");

                    b.HasKey("paperspaperId", "usersUserId");

                    b.HasIndex("usersUserId");

                    b.ToTable("PaperUser");
                });

            modelBuilder.Entity("DemandePFEUser", b =>
                {
                    b.HasOne("ENISdotNet.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ENISdotNet.Models.DemandePFE", null)
                        .WithMany()
                        .HasForeignKey("demandesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ENISdotNet.Models.Section", b =>
                {
                    b.HasOne("ENISdotNet.Models.Departement", "Departement")
                        .WithMany("sections")
                        .HasForeignKey("DepartementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departement");
                });

            modelBuilder.Entity("ENISdotNet.Models.User", b =>
                {
                    b.HasOne("ENISdotNet.Models.Section", "section")
                        .WithMany("Users")
                        .HasForeignKey("SectionId");

                    b.Navigation("section");
                });

            modelBuilder.Entity("PaperUser", b =>
                {
                    b.HasOne("ENISdotNet.Models.Paper", null)
                        .WithMany()
                        .HasForeignKey("paperspaperId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ENISdotNet.Models.User", null)
                        .WithMany()
                        .HasForeignKey("usersUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ENISdotNet.Models.Departement", b =>
                {
                    b.Navigation("sections");
                });

            modelBuilder.Entity("ENISdotNet.Models.Section", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}