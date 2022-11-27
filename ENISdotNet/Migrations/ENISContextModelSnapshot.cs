﻿// <auto-generated />
using ENISdotNet;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ENISdotNet.Migrations
{
    [DbContext(typeof(ENISContext))]
    partial class ENISContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ENISdotNet.Models.DemandePFE", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("approved_at")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("demanded_at")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("demandes");
                });

            modelBuilder.Entity("ENISdotNet.Models.Departement", b =>
                {
                    b.Property<int>("DepartementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartementId"), 1L, 1);

                    b.Property<string>("spacialitée")
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("approved_at")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("demanded_at")
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("schoolYear")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sectionName")
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

                    b.Property<int>("SectionId")
                        .HasColumnType("int");

                    b.Property<string>("firstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("phoneNumber")
                        .HasColumnType("int");

                    b.Property<string>("role")
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

            modelBuilder.Entity("ENISdotNet.Models.DemandePFE", b =>
                {
                    b.HasOne("ENISdotNet.Models.User", "user")
                        .WithMany("demandes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
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
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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

            modelBuilder.Entity("ENISdotNet.Models.User", b =>
                {
                    b.Navigation("demandes");
                });
#pragma warning restore 612, 618
        }
    }
}
