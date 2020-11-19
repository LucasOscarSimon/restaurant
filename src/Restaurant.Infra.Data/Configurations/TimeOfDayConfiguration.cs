using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain;

namespace Restaurant.Infra.Data.Configurations
{
    public class TimeOfDayConfiguration : IEntityTypeConfiguration<TimeOfDay>
    {
        public void Configure(EntityTypeBuilder<TimeOfDay> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasData(new List<TimeOfDay>(
                new[]
                {
                    new TimeOfDay
                    {
                        Id = 1,
                        Description = "Morning"
                    },
                    new TimeOfDay
                    {
                        Id = 2,
                        Description = "Night"
                    }
                }
            ));

            builder.ToTable("TimeOfDay");
        }
    }
}