using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace second_try.Models.Configuration
{
    public class ProfileConfiguration: IEntityTypeConfiguration<Profile>
    {
        public void Configure (EntityTypeBuilder<Profile> builder)
        {
            builder
                .HasIndex(p => p.UserId)
                .IsUnique();
        }
    }
}
