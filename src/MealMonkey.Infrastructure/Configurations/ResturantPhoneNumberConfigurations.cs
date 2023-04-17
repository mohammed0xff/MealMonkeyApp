using MealMonkey.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealMonkey.Infrastructure.Configurations
{
    public class ResturantPhoneNumberConfigurations : IEntityTypeConfiguration<ResturantPhoneNumber>
    {
        public void Configure(EntityTypeBuilder<ResturantPhoneNumber> builder)
        {
            // Properties
            builder.Property(rpm => rpm.PhoneNumber)
                .HasMaxLength(15)
                .IsRequired();

            // Relationships with
            // Resturant
            builder.HasOne<Resturant>(rpm => rpm.Resturant)
                .WithMany(r => r.ResturantPhoneNumbers)
                .HasForeignKey(rpm => rpm.ResturantId)
                .IsRequired();
        }
    }
}
