﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MvcFlight.Data;

#nullable disable

namespace dotnet_flights_mvc.Migrations
{
    [DbContext(typeof(MvcFlightContext))]
    [Migration("20240830194751_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("MvcFlight.Models.Flight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Airline")
                        .HasColumnType("TEXT");

                    b.Property<string>("Airport")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Departs")
                        .HasColumnType("TEXT");

                    b.Property<int>("FlightNo")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Flight");
                });
#pragma warning restore 612, 618
        }
    }
}
