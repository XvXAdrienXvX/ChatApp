using ChatApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatApp.Infrastructure.Config
{
    public class UserGroupConfiguration : IEntityTypeConfiguration<UserGroup>
    {
        public void Configure(EntityTypeBuilder<UserGroup> builder)
        {
            builder.HasKey(ug => new { ug.UserId, ug.GroupId });

            builder.HasOne(ug => ug.User)
                .WithMany(u => u.UserGroups) 
                .HasForeignKey(ug => ug.UserId)
                .IsRequired();

            builder.HasOne(ug => ug.Group)
                .WithMany(g => g.UserGroups)  
                .HasForeignKey(ug => ug.GroupId)
                .IsRequired();
        }
    }
}
