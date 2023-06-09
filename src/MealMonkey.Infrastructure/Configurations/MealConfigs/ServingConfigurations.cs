﻿using MealMonkey.Domain.Entities.MealEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MealMonkey.Infrastructure.Configurations.MealConfigs
{
    public class ServingConfigurations : IEntityTypeConfiguration<Serving>
    {
        public void Configure(EntityTypeBuilder<Serving> builder)
        {
            // Properties
            builder.HasKey(x => x.Id);

            builder.ToTable(nameof(ApplicationDbContext.Servings));

            builder.Property(x => x.Name)
                .HasMaxLength(20)
                .IsRequired();
        }
    }
}
