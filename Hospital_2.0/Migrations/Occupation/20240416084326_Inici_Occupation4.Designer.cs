﻿// <auto-generated />
using System;
using Hospital_2._0.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Hospital_2._0.Migrations.Occupation
{
    [DbContext(typeof(OccupationContext))]
    [Migration("20240416084326_Inici_Occupation4")]
    partial class Inici_Occupation4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Hospital_2._0.Models.Occupation", b =>
                {
                    b.Property<int>("OccupationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OccupationId"));

                    b.Property<DateTime?>("DateOccupation")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IdDoctor")
                        .HasColumnType("int");

                    b.Property<int?>("IdPaciente")
                        .HasColumnType("int");

                    b.Property<int?>("State")
                        .HasColumnType("int");

                    b.HasKey("OccupationId");

                    b.ToTable("Occupations");
                });
#pragma warning restore 612, 618
        }
    }
}