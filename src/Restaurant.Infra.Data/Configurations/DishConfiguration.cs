using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain;

namespace Restaurant.Infra.Data.Configurations
{
    public class DishConfiguration : IEntityTypeConfiguration<Dish>
    {
        public void Configure(EntityTypeBuilder<Dish> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasData(new List<Dish>(
                new[]
                {
                    new Dish
                    {
                        Id = 1,
                        DishTypeId = 1,
                        Description = "eggs",
                        TimeOfDayId = 1,
                    },
                    new Dish
                    {
                        Id = 2,
                        DishTypeId = 2,
                        Description = "Toast",
                        TimeOfDayId = 1,
                    },
                    new Dish
                    {
                        Id = 3,
                        DishTypeId = 3,
                        Description = "coffee",
                        TimeOfDayId = 1,
                    },
                    new Dish
                    {
                        Id = 4,
                        DishTypeId = 1,
                        Description = "steak",
                        TimeOfDayId = 2,
                    },
                    new Dish
                    {
                        Id = 5,
                        DishTypeId = 2,
                        Description = "potato",
                        TimeOfDayId = 2,
                    },
                    new Dish
                    {
                        Id = 6,
                        DishTypeId = 3,
                        Description = "wine",
                        TimeOfDayId = 2,
                    },
                    new Dish
                    {
                        Id = 7,
                        DishTypeId = 4,
                        Description = "cake",
                        TimeOfDayId = 2,
                    },
                }));

            builder.ToTable("Dish");
        }
    }
}