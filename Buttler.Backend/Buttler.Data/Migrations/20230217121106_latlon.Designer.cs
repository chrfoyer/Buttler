﻿// <auto-generated />
using System;
using Buttler.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Buttler.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230217121106_latlon")]
    partial class latlon
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Buttler.Domain.Model.Report", b =>
                {
                    b.Property<int>("ReportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ReportId"));

                    b.Property<int>("NumberOfWaste")
                        .HasColumnType("integer");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("WasteType")
                        .HasColumnType("integer");

                    b.Property<double>("latitude")
                        .HasColumnType("double precision");

                    b.Property<double>("longitude")
                        .HasColumnType("double precision");

                    b.HasKey("ReportId");

                    b.ToTable("Reports");
                });
#pragma warning restore 612, 618
        }
    }
}
