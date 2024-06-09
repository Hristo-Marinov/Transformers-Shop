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
        public DbSet<Category> Categories { get; set; }
        public DbSet<Rating> Ratings { get; set; }

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

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name)
                      .IsRequired()
                      .HasMaxLength(100);
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Stars)
                      .IsRequired();
                entity.Property(e => e.Comment)
                      .HasMaxLength(1000);
                entity.Property(e => e.Date)
                      .IsRequired();

                entity.HasOne(e => e.User)
                      .WithMany()
                      .HasForeignKey(e => e.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

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
                new Product { Id = 1, Name = "Optimus Prime", Picture = "https://c4.wallpaperflare.com/wallpaper/768/872/3/transformers-robot-wallpaper-preview.jpg", Description = "Optimus Prime is the noble and heroic leader of the Autobots, a faction of sentient robots from the planet Cybertron. He transforms into a red and blue semi-truck and is known for his strong sense of justice, unwavering courage, and self-sacrifice. Optimus Prime believes in freedom for all sentient beings and is a skilled and powerful warrior. He is often seen wielding his iconic energy axe and Ion Blaster in battle. Optimus Prime's leadership, wisdom, and compassion make him a beloved and respected figure among the Autobots and their allies.", StockCount = 10, CategoryId = 1},
                new Product { Id = 2, Name = "Bumblebee", Picture = "https://i.pinimg.com/736x/86/e9/35/86e9359600ada784d2712321b4c2b1a9.jpg", Description = "Bumblebee is one of the most well-known and endearing Autobots. He transforms into a yellow compact car, often depicted as a Volkswagen Beetle or a Chevrolet Camaro in various adaptations. Bumblebee is characterized by his loyalty, bravery, and resourcefulness. Despite his smaller size compared to other Autobots, Bumblebee is a fierce and agile fighter, often taking on scouting and espionage missions due to his speed and stealth. He has a strong bond with the humans he befriends, particularly with characters like Sam Witwicky in the live-action films.", StockCount = 10, CategoryId = 1 },
                new Product { Id = 3, Name = "Megatron", Picture = "https://wallpapercave.com/wp/wp3466402.jpg", Description = "Megatron is the ruthless and powerful leader of the Decepticons, the main antagonists of the Transformers universe. He transforms into various forms depending on the adaptation, including a Walther P38 pistol, a tank, or a Cybertronian jet. Megatron's primary goal is to conquer Cybertron and, eventually, the universe, believing that peace can only be achieved through tyranny. He is a formidable combatant with immense strength, advanced weaponry, and a keen tactical mind. Megatron's leadership is marked by fear and oppression, making him a formidable foe to Optimus Prime and the Autobots.", StockCount = 10, CategoryId = 2 },
                new Product { Id = 4, Name = "Sideswipe", Picture = "https://wallpapercave.com/wp/wp3466400.jpg", Description = "Sideswipe is a sleek and stylish Autobot known for his speed, agility, and combat prowess. He typically transforms into a red or silver sports car, such as a Lamborghini or a Chevrolet Corvette, depending on the adaptation. Sideswipe is a skilled warrior who enjoys the thrill of battle and has a competitive nature. He is often depicted as a fearless and daring fighter, willing to take risks to achieve victory. Sideswipe's combat skills are complemented by his twin arm-mounted blades or swords, making him a formidable opponent in close-quarters combat. He is also known for his witty and sometimes cocky personality, adding a dynamic edge to the Autobot team.", StockCount = 10, CategoryId = 1 },
                new Product { Id = 5, Name = "Grimlock", Picture = "https://i.pinimg.com/736x/c4/fb/9c/c4fb9c7c55f74fa4141a4b144f2b5f7e.jpg", Description = "Grimlock is the fierce and powerful leader of the Dinobots, a subgroup of Autobots. He transforms into a mechanical Tyrannosaurus Rex, making him one of the most imposing and fearsome Transformers. Grimlock is characterized by his immense strength, combat prowess, and a stubborn, often rebellious personality. Unlike most Autobots, Grimlock prefers brute force over strategic planning and is known for his straightforward, no-nonsense approach to battle. He often wields an energy sword and a double-barreled rocket launcher in his robot form.\r\n\r\nDespite his gruff demeanor and limited speech capabilities (often speaking in broken sentences like \"Me Grimlock, king!\"), Grimlock possesses a strong sense of loyalty to his fellow Dinobots and the Autobots. He has a deep disdain for the Decepticons and relishes in the opportunity to fight them. Grimlock's leadership of the Dinobots is marked by his protective nature towards his team, and while he may question Optimus Prime's decisions at times, he ultimately respects him as a leader.\r\n\r\nGrimlock's unique transformation and his raw, primal power make him a standout character in the Transformers universe, often providing a mix of muscle and unpredictability to the Autobot ranks.", StockCount = 10, CategoryId = 3 }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Autobot" },
                new Category { Id = 2, Name = "Decepticon" },
                new Category { Id = 3, Name = "Dinobot" }
            );

        }
    }
}
