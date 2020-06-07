﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WeddingPlanner.Models;

namespace WeddingPlanner.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20191209195718_second")]
    partial class second
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("WeddingPlanner.Models.Arrangement", b =>
                {
                    b.Property<int>("ArrangementId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("UserId");

                    b.Property<int>("WeddingId");

                    b.HasKey("ArrangementId");

                    b.HasIndex("UserId");

                    b.HasIndex("WeddingId");

                    b.ToTable("Arrangements");
                });

            modelBuilder.Entity("WeddingPlanner.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WeddingPlanner.Models.Wedding", b =>
                {
                    b.Property<int>("WeddingId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("DateOf");

                    b.Property<string>("FirstHuman")
                        .IsRequired();

                    b.Property<string>("SecondHuman")
                        .IsRequired();

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("WeddingId");

                    b.ToTable("Weddings");
                });

            modelBuilder.Entity("WeddingPlanner.Models.Arrangement", b =>
                {
                    b.HasOne("WeddingPlanner.Models.User", "User")
                        .WithMany("Marriages")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WeddingPlanner.Models.Wedding", "Wedding")
                        .WithMany("Attendants")
                        .HasForeignKey("WeddingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}