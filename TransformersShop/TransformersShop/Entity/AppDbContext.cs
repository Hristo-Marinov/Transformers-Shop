using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace TransformersShop.Entity
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cart>()
                .HasOne(c => c.User)
                .WithMany(u => u.Carts)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<Cart>()
                .HasOne(c => c.Product)
                .WithMany()
                .HasForeignKey(c => c.ProductId);

            SeedAdminUser(modelBuilder);
            SeedProducts(modelBuilder);
        }

        private void SeedAdminUser(ModelBuilder modelBuilder)
        {
            const string ADMIN_ROLE_ID = "1";
            const string ADMIN_USER_ID = "1";

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = ADMIN_ROLE_ID,
                Name = "Admin",
                NormalizedName = "ADMIN"
            });

            var hasher = new PasswordHasher<ApplicationUser>();
            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = ADMIN_USER_ID,
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Admin@123"),
                SecurityStamp = string.Empty,
                IsAdmin = true
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ADMIN_ROLE_ID,
                UserId = ADMIN_USER_ID
            });
        }

        private void SeedProducts(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Transformer 1", Picture = "https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/f/9ece39f6-6737-42b8-b282-f99688062708/d6e4o93-ff76b235-071a-47e8-b3d0-9b02147fbd0c.jpg/v1/fill/w_525,h_350,q_70,strp/tf_fanart___autobots_vacation_ver2_by_goddessmechanic_d6e4o93-350t.jpg?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJ1cm46YXBwOjdlMGQxODg5ODIyNjQzNzNhNWYwZDQxNWVhMGQyNmUwIiwiaXNzIjoidXJuOmFwcDo3ZTBkMTg4OTgyMjY0MzczYTVmMGQ0MTVlYTBkMjZlMCIsIm9iaiI6W1t7ImhlaWdodCI6Ijw9NTMzIiwicGF0aCI6IlwvZlwvOWVjZTM5ZjYtNjczNy00MmI4LWIyODItZjk5Njg4MDYyNzA4XC9kNmU0bzkzLWZmNzZiMjM1LTA3MWEtNDdlOC1iM2QwLTliMDIxNDdmYmQwYy5qcGciLCJ3aWR0aCI6Ijw9ODAwIn1dXSwiYXVkIjpbInVybjpzZXJ2aWNlOmltYWdlLm9wZXJhdGlvbnMiXX0.vdyCpLE2-clAoreexFRcOwy12j2HnSDxKoenEOZltSQ", Description = "Description for Transformer 1", StockCount = 10 },
                new Product { Id = 2, Name = "Transformer 2", Picture = "https://media.tenor.com/r06Prd4E5i0AAAAe/transformers-funny.png", Description = "Description for Transformer 2", StockCount = 10 },
                new Product { Id = 3, Name = "Transformer 3", Picture = "https://i.pinimg.com/736x/3e/87/a1/3e87a13aedb09fcaac9ce75b5ad93d27.jpg", Description = "Description for Transformer 3", StockCount = 10 },
                new Product { Id = 4, Name = "Transformer 4", Picture = "https://i.pinimg.com/originals/9f/bf/05/9fbf05e55cabc5e5ba61e5df243561d5.gif", Description = "Description for Transformer 4", StockCount = 10 }
            );

        }
    }
}
