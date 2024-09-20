﻿// <auto-generated />
using System;
using Gym.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Gym.Migrations
{
    [DbContext(typeof(GymContext))]
    partial class GymContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Gym.Models.Branch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EquipmentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Founded")
                        .HasColumnType("datetime2");

                    b.Property<int?>("SubscriptionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EquipmentId");

                    b.HasIndex("SubscriptionId");

                    b.ToTable("Branch", (string)null);
                });

            modelBuilder.Entity("Gym.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SubscriptionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SubscriptionId");

                    b.ToTable("Client", (string)null);
                });

            modelBuilder.Entity("Gym.Models.Equipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MuscleGroup")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<DateTime>("PurchasedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Equipment", (string)null);
                });

            modelBuilder.Entity("Gym.Models.Subscription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Expires")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Started")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Subscription", (string)null);
                });

            modelBuilder.Entity("Gym.Models.Branch", b =>
                {
                    b.HasOne("Gym.Models.Equipment", null)
                        .WithMany("Branches")
                        .HasForeignKey("EquipmentId");

                    b.HasOne("Gym.Models.Subscription", null)
                        .WithMany("Branches")
                        .HasForeignKey("SubscriptionId");
                });

            modelBuilder.Entity("Gym.Models.Client", b =>
                {
                    b.HasOne("Gym.Models.Subscription", null)
                        .WithMany("Clients")
                        .HasForeignKey("SubscriptionId");
                });

            modelBuilder.Entity("Gym.Models.Equipment", b =>
                {
                    b.Navigation("Branches");
                });

            modelBuilder.Entity("Gym.Models.Subscription", b =>
                {
                    b.Navigation("Branches");

                    b.Navigation("Clients");
                });
#pragma warning restore 612, 618
        }
    }
}
