﻿// <auto-generated />
using System;
using AppointmentAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AppointmentAPI.Migrations
{
    [DbContext(typeof(AppointmentDbContext))]
    partial class AppointmentDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.10");

            modelBuilder.Entity("AppointmentAPI.Models.AppointmentRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("AppointmentDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("HL7Message")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MessageId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ParsedJson")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PatientId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("AppointmentRecords");
                });
#pragma warning restore 612, 618
        }
    }
}
