using BugTracker.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace BugTracker.Persistence.EntityTypeConfiguration
{
    public class BugConfiguration : IEntityTypeConfiguration<Bug>
    {
        public void Configure(EntityTypeBuilder<Bug> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id).IsUnique();
            builder.Property(x => x.Description).HasMaxLength(250);
            builder.Property(x => x.Status)
                .HasConversion(x => x.ToString(), x => Enum.Parse<Status>(x));
            builder.Property(x => x.Priority)
                .HasConversion(x => x.ToString(), x => Enum.Parse<Priority>(x));
        }
    }
}
