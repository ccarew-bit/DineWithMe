﻿// <auto-generated />
using System;
using DineWithMe.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DineWithMe.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20200426155249_addedAgreementMadeBool")]
    partial class addedAgreementMadeBool
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("DineWithMe.Models.Agreement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("FriendApproved")
                        .HasColumnType("boolean");

                    b.Property<int?>("FriendId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsAgreementMade")
                        .HasColumnType("boolean");

                    b.Property<int>("RequestId")
                        .HasColumnType("integer");

                    b.Property<bool>("RequestorApproved")
                        .HasColumnType("boolean");

                    b.Property<int?>("RequestorId")
                        .HasColumnType("integer");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("FriendId");

                    b.HasIndex("RequestId");

                    b.HasIndex("RequestorId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Agreements");
                });

            modelBuilder.Entity("DineWithMe.Models.Request", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("FriendId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsRequestAccepted")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsRequestDenied")
                        .HasColumnType("boolean");

                    b.Property<int>("RequestorId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Time")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("FriendId");

                    b.HasIndex("RequestorId");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("DineWithMe.Models.Restaurant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Expenses")
                        .HasColumnType("text");

                    b.Property<string>("Hours")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Reviews")
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Restaurants");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Expenses = "$$",
                            Hours = "9am-5pm",
                            Name = "Ceviche tapas St.Pete",
                            Reviews = "GREAT",
                            Type = "Spanish"
                        },
                        new
                        {
                            Id = 2,
                            Expenses = "$$",
                            Hours = "9am-5pm",
                            Name = "Red Mesa",
                            Reviews = "GREAT",
                            Type = "Mexican"
                        },
                        new
                        {
                            Id = 3,
                            Expenses = "$$",
                            Hours = "9am-5pm",
                            Name = "Parkshore Grill",
                            Reviews = "GREAT",
                            Type = "American"
                        },
                        new
                        {
                            Id = 4,
                            Expenses = "$$",
                            Hours = "9am-5pm",
                            Name = "Harvey's 4th Street Grill",
                            Reviews = "GREAT",
                            Type = "Spanish"
                        },
                        new
                        {
                            Id = 5,
                            Expenses = "$$",
                            Hours = "9am-5pm",
                            Name = "BellaBrava",
                            Reviews = "GREAT",
                            Type = "Pizza"
                        });
                });

            modelBuilder.Entity("DineWithMe.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("HashedPassword")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DineWithMe.Models.Agreement", b =>
                {
                    b.HasOne("DineWithMe.Models.User", "Friend")
                        .WithMany()
                        .HasForeignKey("FriendId");

                    b.HasOne("DineWithMe.Models.Request", "Request")
                        .WithMany()
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DineWithMe.Models.User", "Requestor")
                        .WithMany()
                        .HasForeignKey("RequestorId");

                    b.HasOne("DineWithMe.Models.Restaurant", "Restaurant")
                        .WithMany()
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DineWithMe.Models.Request", b =>
                {
                    b.HasOne("DineWithMe.Models.User", "Friend")
                        .WithMany()
                        .HasForeignKey("FriendId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DineWithMe.Models.User", "Requestor")
                        .WithMany()
                        .HasForeignKey("RequestorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
