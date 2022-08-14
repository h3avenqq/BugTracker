using BugTracker.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BugTracker.Persistence.EntityTypeConfiguration
{
    public class UserProjectConfigurations : IEntityTypeConfiguration<User_Project>
    {
        public void Configure(EntityTypeBuilder<User_Project> builder)
        {
            builder.HasNoKey();
        }
    }
}
