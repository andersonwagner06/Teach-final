using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Teach.Infra.CrossCutting.Identity.Models;

namespace Teach.Infra.CrossCutting.Identity.Mapping
{
    public class ApplicationUserRoleMap : IEntityTypeConfiguration<ApplicationUserRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserRole> builder)
        {
            builder.ToTable(name: "UserRole");

        }
    }
}
