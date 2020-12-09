// Copyright (c) 2020 Lykke Corp.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using MarginTrading.AssetService.Core.Holidays;
using MarginTrading.AssetService.SqlRepositories.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;

namespace MarginTrading.AssetService.SqlRepositories.EntityConfigurations
{
    public class MarketSettingsEntityConfiguration : IEntityTypeConfiguration<MarketSettingsEntity>
    {
        public void Configure(EntityTypeBuilder<MarketSettingsEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.NormalizedName).IsUnique();

            builder.OwnsOne(x => x.HolidaySchedule,
                x =>
                {
                    x.Property(p => p.Schedule)
                        .HasConversion(
                            p => JsonConvert.SerializeObject(p.Holidays.Select(h => h.ToString())),
                            p => new HolidaySchedule(JsonConvert.DeserializeObject<List<string>>(p)));
                });

            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Timezone).IsRequired();

            builder.Property(x => x.Open)
                .HasConversion(HoursConverter)
                .IsRequired();
            
            builder.Property(x => x.Close)
                .HasConversion(HoursConverter)
                .IsRequired();
            
            builder.Property(x => x.Dividends871M).IsRequired();
            builder.Property(x => x.DividendsLong).IsRequired();
            builder.Property(x => x.DividendsShort).IsRequired();

            builder.Property(p => p.Dividends871M)
                .HasColumnType("decimal(18,13)");
            builder.Property(p => p.DividendsLong)
                .HasColumnType("decimal(18,13)");
            builder.Property(p => p.DividendsShort)
                .HasColumnType("decimal(18,13)");
        }
        
        private static readonly ValueConverter<TimeSpan[], string> HoursConverter = new ValueConverter<TimeSpan[], string>(
            v => string.Join(";", v),
            v => v.Split(";", StringSplitOptions.RemoveEmptyEntries).Select(TimeSpan.Parse).ToArray()); 
    }
}