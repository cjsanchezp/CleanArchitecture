using CleanArchitecture.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                new ApplicationUser
                {
                    Id = "2b45040d-8715-403d-bc5b-ddb632ce88cc",
                    Email = "admin@localhost.com",
                    NormalizedEmail = "admin@localhost.com",
                    Nombre = "Cristian",
                    Apellidos = "Sanchez",
                    UserName = "crisape",
                    NormalizedUserName = "crisape",
                    PasswordHash = hasher.HashPassword(null, "Crisape2025$"),
                    EmailConfirmed = true,
                },
                new ApplicationUser
                {
                    Id = "b6d4ffbd-7833-4ec0-88dc-36f4f32e8ee3",
                    Email = "juanperez@localhost.com",
                    NormalizedEmail = "juanperez@localhost.com",
                    Nombre = "Juan",
                    Apellidos = "Perez",
                    UserName = "juanperez",
                    NormalizedUserName = "juanperez",
                    PasswordHash = hasher.HashPassword(null, "Crisape2025$"),
                    EmailConfirmed = true,
                }

                );
        }
    }
}
