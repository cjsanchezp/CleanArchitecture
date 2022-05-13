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
                    Id = "d55811f3-0315-4963-9f00-cd2c71b469a3",
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
                    Id = "5e292491-e6c3-47a3-93bd-1bdfef43166c",
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
