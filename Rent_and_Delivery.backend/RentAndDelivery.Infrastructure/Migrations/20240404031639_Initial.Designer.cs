﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RentAndDelivery.Infrastructure.Context;

#nullable disable

namespace RentAndDelivery.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240404031639_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("RentAndDelivery.Domain.Entities.Admin", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("Admins");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4faa9cab-f205-40cb-5953-08dc489cfb2d"),
                            CreatedOn = new DateTime(2024, 4, 4, 0, 16, 38, 779, DateTimeKind.Utc).AddTicks(2230),
                            Name = "Admin"
                        });
                });

            modelBuilder.Entity("RentAndDelivery.Domain.Entities.DeliveryPerson", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("BirthDate")
                        .IsRequired()
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ImageCNH")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)");

                    b.Property<string>("LicenseNumberCNH")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("LicenseType")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<Guid?>("OrderId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("DeliveryPersons");

                    b.HasData(
                        new
                        {
                            Id = new Guid("15ef9e35-e3af-4a70-826d-88edba8efcc0"),
                            BirthDate = new DateTime(2004, 4, 4, 0, 16, 38, 779, DateTimeKind.Utc).AddTicks(3454),
                            CNPJ = "74979006000199",
                            CreatedOn = new DateTime(2024, 4, 4, 0, 16, 38, 779, DateTimeKind.Utc).AddTicks(3463),
                            ImageCNH = "./images/imageCNH.jpg",
                            LicenseNumberCNH = "30222894101",
                            LicenseType = 1,
                            Name = "John Doe Test"
                        });
                });

            modelBuilder.Entity("RentAndDelivery.Domain.Entities.Motorcycle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Plate")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<int?>("Year")
                        .IsRequired()
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasAlternateKey("Plate")
                        .HasName("UniqueKey_Plate");

                    b.ToTable("Motorcycles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6c31f522-56b1-4bc2-a8c9-585627c23318"),
                            CreatedOn = new DateTime(2024, 4, 4, 0, 16, 38, 779, DateTimeKind.Utc).AddTicks(4779),
                            Model = "Factor 125",
                            Plate = "OFL0823",
                            Status = 1,
                            Year = 2023
                        });
                });

            modelBuilder.Entity("RentAndDelivery.Domain.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("AcceptedOrderDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeliveredOrderDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("DeliveryPersonId")
                        .HasColumnType("uuid");

                    b.Property<int>("OrderStatusStatus")
                        .HasColumnType("integer");

                    b.Property<float?>("RaceValue")
                        .IsRequired()
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("DeliveryPersonId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = new Guid("814270d0-e6f8-4b95-b1c8-c74ba38e0381"),
                            CreatedOn = new DateTime(2024, 4, 4, 0, 16, 38, 779, DateTimeKind.Utc).AddTicks(5671),
                            OrderStatusStatus = 1,
                            RaceValue = 50f
                        });
                });

            modelBuilder.Entity("RentAndDelivery.Domain.Entities.OrderNotification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("DeliveryPersonId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("DeliveryPersonId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderNotifications");
                });

            modelBuilder.Entity("RentAndDelivery.Domain.Entities.RentalPlan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<float?>("AdditionalValuePerDay")
                        .IsRequired()
                        .HasColumnType("real");

                    b.Property<float?>("CostPerDay")
                        .IsRequired()
                        .HasColumnType("real");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<float?>("FineInPercentage")
                        .IsRequired()
                        .HasColumnType("real");

                    b.Property<int?>("PlanDays")
                        .IsRequired()
                        .HasColumnType("integer");

                    b.Property<string>("PlanName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("RentalPlans");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3531a2ac-015f-4b7e-95b6-8f6e54a040bb"),
                            AdditionalValuePerDay = 50f,
                            CostPerDay = 30f,
                            CreatedOn = new DateTime(2024, 4, 4, 0, 16, 38, 779, DateTimeKind.Utc).AddTicks(7848),
                            FineInPercentage = 20f,
                            PlanDays = 7,
                            PlanName = "7_Days"
                        },
                        new
                        {
                            Id = new Guid("54b78006-d2c0-4041-ad81-5e88b84142c0"),
                            AdditionalValuePerDay = 50f,
                            CostPerDay = 28f,
                            CreatedOn = new DateTime(2024, 4, 4, 0, 16, 38, 779, DateTimeKind.Utc).AddTicks(7865),
                            FineInPercentage = 40f,
                            PlanDays = 15,
                            PlanName = "15_Days"
                        },
                        new
                        {
                            Id = new Guid("5b17845c-d0a7-4a84-b380-a0ac18382b5a"),
                            AdditionalValuePerDay = 50f,
                            CostPerDay = 22f,
                            CreatedOn = new DateTime(2024, 4, 4, 0, 16, 38, 779, DateTimeKind.Utc).AddTicks(7869),
                            FineInPercentage = 60f,
                            PlanDays = 30,
                            PlanName = "30_Days"
                        });
                });

            modelBuilder.Entity("RentAndDelivery.Domain.Entities.VehicleRental", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("DeliveryPersonId")
                        .HasMaxLength(100)
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("EndDate")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("EstimatedEndDate")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("MotorcycleId")
                        .HasMaxLength(100)
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("StartDate")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("timestamp with time zone");

                    b.Property<float?>("TotalAmount")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("DeliveryPersonId");

                    b.HasIndex("MotorcycleId");

                    b.ToTable("VehiclesRentals");
                });

            modelBuilder.Entity("RentAndDelivery.Domain.Entities.DeliveryPerson", b =>
                {
                    b.HasOne("RentAndDelivery.Domain.Entities.Order", null)
                        .WithMany("DeliveryPersons")
                        .HasForeignKey("OrderId");
                });

            modelBuilder.Entity("RentAndDelivery.Domain.Entities.Order", b =>
                {
                    b.HasOne("RentAndDelivery.Domain.Entities.DeliveryPerson", "DeliveryPerson")
                        .WithMany("Orders")
                        .HasForeignKey("DeliveryPersonId");

                    b.Navigation("DeliveryPerson");
                });

            modelBuilder.Entity("RentAndDelivery.Domain.Entities.OrderNotification", b =>
                {
                    b.HasOne("RentAndDelivery.Domain.Entities.DeliveryPerson", "DeliveryPerson")
                        .WithMany()
                        .HasForeignKey("DeliveryPersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RentAndDelivery.Domain.Entities.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DeliveryPerson");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("RentAndDelivery.Domain.Entities.VehicleRental", b =>
                {
                    b.HasOne("RentAndDelivery.Domain.Entities.DeliveryPerson", "DeliveryPerson")
                        .WithMany()
                        .HasForeignKey("DeliveryPersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RentAndDelivery.Domain.Entities.Motorcycle", "Motorcycle")
                        .WithMany()
                        .HasForeignKey("MotorcycleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DeliveryPerson");

                    b.Navigation("Motorcycle");
                });

            modelBuilder.Entity("RentAndDelivery.Domain.Entities.DeliveryPerson", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("RentAndDelivery.Domain.Entities.Order", b =>
                {
                    b.Navigation("DeliveryPersons");
                });
#pragma warning restore 612, 618
        }
    }
}