﻿// <auto-generated />
using System;
using Heroes.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Heroes.Infrastructure.Migrations
{
    [DbContext(typeof(HeroesDbContext))]
    [Migration("20250416032134_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Heroes.Domain.Entities.Hero", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<float>("Height")
                        .HasColumnType("real");

                    b.Property<string>("HeroName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("Weight")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Heroes");
                });

            modelBuilder.Entity("Heroes.Domain.Entities.HeroSuperPower", b =>
                {
                    b.Property<Guid>("HeroId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SuperPowerId")
                        .HasColumnType("uuid");

                    b.HasKey("HeroId", "SuperPowerId");

                    b.HasIndex("SuperPowerId");

                    b.ToTable("HeroSuperPowers");
                });

            modelBuilder.Entity("Heroes.Domain.Entities.SuperPower", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("SuperPowers");
                });

            modelBuilder.Entity("Heroes.Domain.Entities.HeroSuperPower", b =>
                {
                    b.HasOne("Heroes.Domain.Entities.Hero", "Hero")
                        .WithMany("HeroSuperPowers")
                        .HasForeignKey("HeroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Heroes.Domain.Entities.SuperPower", "SuperPower")
                        .WithMany("HeroSuperPowers")
                        .HasForeignKey("SuperPowerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hero");

                    b.Navigation("SuperPower");
                });

            modelBuilder.Entity("Heroes.Domain.Entities.Hero", b =>
                {
                    b.Navigation("HeroSuperPowers");
                });

            modelBuilder.Entity("Heroes.Domain.Entities.SuperPower", b =>
                {
                    b.Navigation("HeroSuperPowers");
                });
#pragma warning restore 612, 618
        }
    }
}
