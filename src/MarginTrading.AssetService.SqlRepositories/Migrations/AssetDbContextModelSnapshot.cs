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
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RegulatoryTypeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UnderlyingCategoryId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

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

                    b.HasIndex("Timestamp");

                    b.ToTable("AuditTrail");
                });

            modelBuilder.Entity("MarginTrading.AssetService.SqlRepositories.Entities.ClientProfileEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsDefault")
                        .HasColumnType("bit");

                    b.Property<string>("RegulatoryProfileId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ClientProfiles");
                });

            modelBuilder.Entity("MarginTrading.AssetService.SqlRepositories.Entities.ClientProfileSettingsEntity", b =>
                {
                    b.Property<string>("ClientProfileId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AssetTypeId")
                        .HasColumnType("nvarchar(450)");

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

                    b.Property<decimal>("Margin")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("OnBehalfFee")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ClientProfileId", "AssetTypeId");

                    b.HasIndex("AssetTypeId");

                    b.ToTable("ClientProfileSettings");
                });

            modelBuilder.Entity("MarginTrading.AssetService.SqlRepositories.Entities.CurrencyEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("Accuracy")
                        .HasColumnType("int");

                    b.Property<string>("InterestRateMdsCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.ToTable("Currencies");
                });

            modelBuilder.Entity("MarginTrading.AssetService.SqlRepositories.Entities.MarketSettingsEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal?>("Dividends871M")
                        .HasColumnType("decimal(18,13)");

                    b.Property<decimal?>("DividendsLong")
                        .HasColumnType("decimal(18,13)");

                    b.Property<decimal?>("DividendsShort")
                        .HasColumnType("decimal(18,13)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("MarketSettings");
                });

            modelBuilder.Entity("MarginTrading.AssetService.SqlRepositories.Entities.ProductCategoryEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(400)")
                        .HasMaxLength(400);

                    b.Property<string>("LocalizationToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(400)")
                        .HasMaxLength(400);

                    b.Property<string>("ParentId")
                        .HasColumnType("nvarchar(400)");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("MarginTrading.AssetService.SqlRepositories.Entities.ProductEntity", b =>
                {
                    b.Property<string>("ProductId")
                        .HasColumnType("nvarchar(400)")
                        .HasMaxLength(400);

                    b.Property<string>("AssetTypeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CategoryId")
                        .IsRequired()
                        .HasColumnType("nvarchar(400)");

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(400)")
                        .HasMaxLength(400);

                    b.Property<int>("ContractSize")
                        .HasColumnType("int")
                        .HasMaxLength(400);

                    b.Property<decimal?>("Dividends871M")
                        .HasColumnType("decimal(18,13)");

                    b.Property<decimal?>("DividendsLong")
                        .HasColumnType("decimal(18,13)");

                    b.Property<decimal?>("DividendsShort")
                        .HasColumnType("decimal(18,13)");

                    b.Property<string>("ForceId")
                        .IsRequired()
                        .HasColumnType("nvarchar(400)")
                        .HasMaxLength(400);

                    b.Property<string>("FreezeInfo")
                        .HasColumnType("nvarchar(2000)")
                        .HasMaxLength(2000);

                    b.Property<decimal>("HedgeCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsDiscontinued")
                        .HasColumnType("bit");

                    b.Property<bool>("IsFrozen")
                        .HasColumnType("bit");

                    b.Property<bool>("IsStarted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSuspended")
                        .HasColumnType("bit");

                    b.Property<string>("IsinLong")
                        .IsRequired()
                        .HasColumnType("nvarchar(400)")
                        .HasMaxLength(400);

                    b.Property<string>("IsinShort")
                        .IsRequired()
                        .HasColumnType("nvarchar(400)")
                        .HasMaxLength(400);

                    b.Property<string>("Issuer")
                        .HasColumnType("nvarchar(400)")
                        .HasMaxLength(400);

                    b.Property<string>("Keywords")
                        .HasColumnType("nvarchar(400)")
                        .HasMaxLength(400);

                    b.Property<string>("MarketId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MarketMakerAssetAccountId")
                        .HasColumnType("nvarchar(400)")
                        .HasMaxLength(400);

                    b.Property<int>("MaxOrderSize")
                        .HasColumnType("int");

                    b.Property<int>("MaxPositionSize")
                        .HasColumnType("int");

                    b.Property<decimal>("MinOrderDistancePercent")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("MinOrderEntryInterval")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("MinOrderSize")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(400)")
                        .HasMaxLength(400);

                    b.Property<string>("NewsId")
                        .HasColumnType("nvarchar(400)")
                        .HasMaxLength(400);

                    b.Property<decimal>("OvernightMarginMultiplier")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Parity")
                        .HasColumnType("int");

                    b.Property<string>("PublicationRic")
                        .IsRequired()
                        .HasColumnType("nvarchar(400)")
                        .HasMaxLength(400);

                    b.Property<string>("SettlementCurrency")
                        .HasColumnType("nvarchar(400)")
                        .HasMaxLength(400);

                    b.Property<bool>("ShortPosition")
                        .HasColumnType("bit");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Tags")
                        .HasColumnType("nvarchar(400)")
                        .HasMaxLength(400);

                    b.Property<string>("TickFormulaId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("TradingCurrencyId")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("UnderlyingMdsCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(400)")
                        .HasMaxLength(400);

                    b.HasKey("ProductId");

                    b.HasIndex("AssetTypeId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("MarketId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("TickFormulaId");

                    b.HasIndex("TradingCurrencyId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("MarginTrading.AssetService.SqlRepositories.Entities.TickFormulaEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PdlLadders")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PdlTicks")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TickFormulas");
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

            modelBuilder.Entity("MarginTrading.AssetService.SqlRepositories.Entities.MarketSettingsEntity", b =>
                {
                    b.OwnsOne("MarginTrading.AssetService.SqlRepositories.Entities.MarketScheduleEntity", "MarketSchedule", b1 =>
                        {
                            b1.Property<string>("MarketSettingsEntityId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("Schedule")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("MarketSettingsEntityId");

                            b1.ToTable("MarketSettings");

                            b1.WithOwner()
                                .HasForeignKey("MarketSettingsEntityId");
                        });

                    b.OwnsMany("MarginTrading.AssetService.SqlRepositories.Entities.HolidayEntity", "Holidays", b1 =>
                        {
                            b1.Property<DateTime>("Date")
                                .HasColumnType("datetime2");

                            b1.Property<string>("MarketSettingsId")
                                .HasColumnType("nvarchar(450)");

                            b1.HasKey("Date", "MarketSettingsId");

                            b1.HasIndex("MarketSettingsId");

                            b1.ToTable("Holidays");

                            b1.WithOwner()
                                .HasForeignKey("MarketSettingsId");
                        });
                });

            modelBuilder.Entity("MarginTrading.AssetService.SqlRepositories.Entities.ProductCategoryEntity", b =>
                {
                    b.HasOne("MarginTrading.AssetService.SqlRepositories.Entities.ProductCategoryEntity", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("MarginTrading.AssetService.SqlRepositories.Entities.ProductEntity", b =>
                {
                    b.HasOne("MarginTrading.AssetService.SqlRepositories.Entities.AssetTypeEntity", "AssetType")
                        .WithMany()
                        .HasForeignKey("AssetTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MarginTrading.AssetService.SqlRepositories.Entities.ProductCategoryEntity", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MarginTrading.AssetService.SqlRepositories.Entities.MarketSettingsEntity", "Market")
                        .WithMany()
                        .HasForeignKey("MarketId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MarginTrading.AssetService.SqlRepositories.Entities.TickFormulaEntity", "TickFormula")
                        .WithMany()
                        .HasForeignKey("TickFormulaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MarginTrading.AssetService.SqlRepositories.Entities.CurrencyEntity", "TradingCurrency")
                        .WithMany()
                        .HasForeignKey("TradingCurrencyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
