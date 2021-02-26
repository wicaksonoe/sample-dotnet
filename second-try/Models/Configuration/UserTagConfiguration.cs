using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace second_try.Models.Configuration
{
    public class UserTagConfiguration : IEntityTypeConfiguration<UserTag>
    {
        public void Configure(EntityTypeBuilder<UserTag> builder)
        {
            builder.HasKey(t => new { t.UserId, t.TagId });

            builder
                .HasOne(ut => ut.User)
                .WithMany(u => u.UserTags)
                .HasForeignKey(ut => ut.UserId);

            builder
                .HasOne(ut => ut.Tag)
                .WithMany(u => u.UserTags)
                .HasForeignKey(ut => ut.TagId);
        }
    }
}
