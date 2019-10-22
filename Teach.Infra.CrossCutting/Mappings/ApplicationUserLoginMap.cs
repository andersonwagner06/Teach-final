using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Teach.Infra.CrossCutting.Identity.Models;

namespace Teach.Infra.CrossCutting.Identity.Mapping
{
    public class ApplicationUserLoginMap : IEntityTypeConfiguration<ApplicationUserLogin>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserLogin> builder)
        {
            builder.ToTable(name: "UserLogin");

        }
    }
}
