﻿// <auto-generated />
using IMS.Server.DataAccess.IMS.Server.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IMS.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200816083304_quote")]
    partial class quote
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("IMS.Shared.Models.Quote", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("TitleCode")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("tblQuotes");
                });

            modelBuilder.Entity("IMS.Shared.Models.TitlesTable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("tblTitles");
                });
#pragma warning restore 612, 618
        }
    }
}
