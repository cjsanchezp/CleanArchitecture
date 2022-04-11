using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Identity.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "00aede9b-4662-49cf-9446-b7ff16580d24",
                    UserId = "2b45040d-8715-403d-bc5b-ddb632ce88cc"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "6c5ecca1-b005-4b39-9a78-3e9859e1b3cb",
                    UserId = "b6d4ffbd-7833-4ec0-88dc-36f4f32e8ee3"
                }
                );
        }
    }
}
