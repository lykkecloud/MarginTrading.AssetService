﻿// <auto-generated />
using System;
using MarginTrading.AssetService.SqlRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MarginTrading.AssetService.SqlRepositories.Migrations
{
    [DbContext(typeof(AssetDbContext))]
    partial class AssetDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MarginTrading.AssetService.SqlRepositories.Entities.AssetTypeEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("RegulatoryTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique();

                    b.ToTable("AssetTypes");
                });

            modelBuilder.Entity("MarginTrading.AssetService.SqlRepositories.Entities.AuditEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CorrelationId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DataDiff")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DataReference")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DataType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AuditTrail");
                });

            modelBuilder.Entity("MarginTrading.AssetService.SqlRepositories.Entities.ClientProfileEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDefault")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("RegulatoryProfileId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique();

                    b.ToTable("ClientProfiles");
                });

            modelBuilder.Entity("MarginTrading.AssetService.SqlRepositories.Entities.ClientProfileSettingsEntity", b =>
                {
                    b.Property<Guid>("ClientProfileId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AssetTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("ExecutionFeesCap")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ExecutionFeesFloor")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ExecutionFeesRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("FinancingFeesRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<decimal>("MarginMin")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PhoneFees")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ClientProfileId", "AssetTypeId");

                    b.HasIndex("AssetTypeId");

                    b.ToTable("ClientProfileSettings");
                });

            modelBuilder.Entity("MarginTrading.AssetService.SqlRepositories.Entities.ClientProfileSettingsEntity", b =>
                {
                    b.HasOne("MarginTrading.AssetService.SqlRepositories.Entities.AssetTypeEntity", "AssetType")
                        .WithMany()
                        .HasForeignKey("AssetTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MarginTrading.AssetService.SqlRepositories.Entities.ClientProfileEntity", "ClientProfile")
                        .WithMany()
                        .HasForeignKey("ClientProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
