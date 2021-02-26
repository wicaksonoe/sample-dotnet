using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace second_try.Models.Configuration
{
    public class UserConfiguration: IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasIndex(u => u.Username)
                .IsUnique();

            builder
                .HasIndex(u => u.Email)
                .IsUnique();

            builder
                .HasMany(v => v.Vehicles)
                .WithOne(u => u.User)
                .HasForeignKey(u => u.UserId);
        }
    }
}
