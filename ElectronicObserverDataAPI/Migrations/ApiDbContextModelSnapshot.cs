﻿// <auto-generated />
using System;
using ElectronicObserverDataAPI.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ElectronicObserverDataAPI.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    partial class ApiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0-preview.5.23280.1");

            modelBuilder.Entity("ElectronicObserverDataAPI.Models.EquipmentUpgradeIssueModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ActualUpgrades")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "actual");

                    b.Property<DateTime>("AddedOn")
                        .HasColumnType("TEXT");

                    b.Property<int>("DataVersion")
                        .HasColumnType("INTEGER")
                        .HasAnnotation("Relational:JsonPropertyName", "data_version");

                    b.Property<int>("Day")
                        .HasColumnType("INTEGER")
                        .HasAnnotation("Relational:JsonPropertyName", "day");

                    b.Property<string>("ExpectedUpgrades")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "expected");

                    b.Property<int>("HelperId")
                        .HasColumnType("INTEGER")
                        .HasAnnotation("Relational:JsonPropertyName", "helperId");

                    b.Property<string>("SoftwareVersion")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "software_version");

                    b.HasKey("Id");

                    b.ToTable("EquipmentUpgradeIssues");
                });

            modelBuilder.Entity("ElectronicObserverDataAPI.Models.QuestTranslationMissingModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("AddedOn")
                        .HasColumnType("TEXT");

                    b.Property<int>("ApiId")
                        .HasColumnType("INTEGER")
                        .HasAnnotation("Relational:JsonPropertyName", "api_id");

                    b.Property<int>("DataVersion")
                        .HasColumnType("INTEGER")
                        .HasAnnotation("Relational:JsonPropertyName", "data_version");

                    b.Property<string>("Desription")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "description");

                    b.Property<string>("SoftwareVersion")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "software_version");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "title");

                    b.HasKey("Id");

                    b.ToTable("QuestTranslationMissing");
                });
#pragma warning restore 612, 618
        }
    }
}
