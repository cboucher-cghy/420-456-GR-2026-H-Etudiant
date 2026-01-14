using Demo.Identity.Web.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Demo.Identity.Web.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser, ApplicationRole, string>(options)
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Pour forcer EF Core à utiliser TPT (tables normalisées)
            builder.Entity<Etudiant>().ToTable(nameof(Etudiant));
            builder.Entity<Enseignant>().ToTable(nameof(Enseignant));

            builder.Entity<ApplicationRole>().HasData(
                [
                new ApplicationRole(){
                    Id= "12341234123412341243",
                    Name=Models.Roles.ADMINISTRATOR
                },
                new ApplicationRole(){
                    Id= "123412355553412341243",
                    Name=Models.Roles.STUDENT
                },
                new ApplicationRole(){
                    Id= "666-666-666",
                    Name=Models.Roles.TEACHER
                }
                ]
                );

        }

        public DbSet<Etudiant> Etudiants { get; set; }
        public DbSet<Enseignant> Enseignants { get; set; }
    }
}
