﻿// <auto-generated />
using System;
using BookingApp.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Booking.Migrations
{
    [DbContext(typeof(BookingContext))]
    partial class BookingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BookingApp.Models.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AppointmentDate");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("DateTime");

                    b.Property<int>("Price");

                    b.Property<DateTime?>("UpdatedAt");

                    b.HasKey("Id");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("BookingApp.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClubId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(1000);

                    b.Property<string>("Oib")
                        .IsRequired();

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(1000);

                    b.Property<DateTime?>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("ClubId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("BookingApp.Models.ClientAppointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AppointmentId");

                    b.Property<int>("ClientId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Price")
                        .IsRequired();

                    b.Property<DateTime?>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentId");

                    b.HasIndex("ClientId");

                    b.ToTable("ClientAppointments");
                });

            modelBuilder.Entity("BookingApp.Models.Club", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(1000);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(1000);

                    b.Property<string>("Oib")
                        .IsRequired();

                    b.Property<DateTime?>("UpdatedAt");

                    b.HasKey("Id");

                    b.ToTable("Clubs");
                });

            modelBuilder.Entity("BookingApp.Models.Trainer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(1000);

                    b.Property<int>("PhoneNumber");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(1000);

                    b.Property<DateTime?>("UpdatedAt");

                    b.HasKey("Id");

                    b.ToTable("Trainers");
                });

            modelBuilder.Entity("BookingApp.Models.Client", b =>
                {
                    b.HasOne("BookingApp.Models.Club", "Club")
                        .WithMany()
                        .HasForeignKey("ClubId");
                });

            modelBuilder.Entity("BookingApp.Models.ClientAppointment", b =>
                {
                    b.HasOne("BookingApp.Models.Appointment", "Appointment")
                        .WithMany("ClientAppointments")
                        .HasForeignKey("AppointmentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("BookingApp.Models.Client", "Client")
                        .WithMany("ClientAppointments")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
