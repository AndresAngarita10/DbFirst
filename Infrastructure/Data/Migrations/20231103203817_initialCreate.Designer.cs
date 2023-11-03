﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    [DbContext(typeof(DbFirstContext))]
    [Migration("20231103203817_initialCreate")]
    partial class initialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("utf8mb4_0900_as_cs")
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.HasCharSet(modelBuilder, "utf8mb4");

            modelBuilder.Entity("Core.Entities.Driver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int?>("Age")
                        .HasColumnType("int")
                        .HasColumnName("age");

                    b.Property<string>("Name")
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("driver", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "Name" }, "name_UNIQUE")
                        .IsUnique();

                    b.ToTable("team", (string)null);
                });

            modelBuilder.Entity("Teamdriver", b =>
                {
                    b.Property<int>("IdTeam")
                        .HasColumnType("int")
                        .HasColumnName("idTeam");

                    b.Property<int>("IdDriver")
                        .HasColumnType("int")
                        .HasColumnName("idDriver");

                    b.HasKey("IdTeam", "IdDriver")
                        .HasName("PRIMARY")
                        .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                    b.HasIndex(new[] { "IdDriver" }, "idDriver_idx");

                    b.ToTable("teamdriver", (string)null);
                });

            modelBuilder.Entity("Teamdriver", b =>
                {
                    b.HasOne("Core.Entities.Driver", null)
                        .WithMany()
                        .HasForeignKey("IdDriver")
                        .IsRequired()
                        .HasConstraintName("idDriver");

                    b.HasOne("Core.Entities.Team", null)
                        .WithMany()
                        .HasForeignKey("IdTeam")
                        .IsRequired()
                        .HasConstraintName("idTeam");
                });
#pragma warning restore 612, 618
        }
    }
}