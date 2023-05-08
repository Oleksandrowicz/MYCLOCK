﻿// <auto-generated />
using System;
using Data_access;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data_access.Migrations
{
    [DbContext(typeof(NotesDBContext))]
    partial class NotesDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Data_access.Entities.AlarmItem", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("ID");

                    b.ToTable("Alarms");
                });

            modelBuilder.Entity("Data_access.Entities.Note", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("MessageNote")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("ID");

                    b.ToTable("Notes");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Date = new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MessageNote = "Go to dantest"
                        },
                        new
                        {
                            ID = 2,
                            Date = new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MessageNote = "Exam Task"
                        },
                        new
                        {
                            ID = 3,
                            Date = new DateTime(2023, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MessageNote = "sait potato"
                        },
                        new
                        {
                            ID = 4,
                            Date = new DateTime(2023, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MessageNote = "by car"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
