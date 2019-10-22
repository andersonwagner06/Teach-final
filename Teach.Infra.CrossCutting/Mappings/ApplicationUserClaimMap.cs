using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Teach.Infra.CrossCutting.Identity.Models;

namespace Teach.Infra.CrossCutting.Identity.Mapping
{
    public class ApplicationUserClaimMap : IEntityTypeConfiguration<ApplicationUserClaim>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserClaim> builder)
        {
            builder.ToTable(name: "UserClaim");

        }
    }
}
