using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Teach.Infra.CrossCutting.Identity.Models;

namespace Teach.Infra.CrossCutting.Identity.Mapping
{
    public class ApplicationUserMap : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.ToTable(name: "User");

            builder.Property(c => c.Name)
                .HasMaxLength(256)
                .IsRequired();
        }
    }
}
