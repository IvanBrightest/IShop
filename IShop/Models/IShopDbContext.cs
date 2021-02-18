using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IShop.Models
{
    public class IShopDbContext : IdentityDbContext<Customer>
    {
        public DbSet<Brand> Brands { get; set; }
        public IShopDbContext(DbContextOptions<IShopDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Ignore<IdentityUserLogin<string>>();
            modelBuilder.Ignore<IdentityUserRole<string>>();
            modelBuilder.Ignore<IdentityUserClaim<string>>();
            modelBuilder.Ignore<IdentityUserToken<string>>();
            modelBuilder.Ignore<IdentityUser<string>>();
            modelBuilder.Ignore<Customer>();

            modelBuilder.Entity<Brand>()
                .HasOne(p => p.Parent)
                .WithMany(t => t.Childrens)
                .HasForeignKey("ParentId")
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
