using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManagementApp.Infrastructure.Identity.Mappings
{
    public class RoleMapping : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(new IdentityRole()
            {
                Id = "2954573f-9b9b-4f8d-9a6f-7a97e281ad82",
                Name = "User",
                NormalizedName = "USER",
            },
            new IdentityRole()
            {
                Id = "9794b8e8-3336-4e37-b904-e6538f1ab033",
                Name = "Admin",
                NormalizedName = "ADMIN",
            });
        }
    }
}
