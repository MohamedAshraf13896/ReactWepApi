using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebAbi.Models
{
    public class GamingStoreDB : IdentityDbContext<ApplicationUser>
    {
        public GamingStoreDB() : base()
        {

        }
        public GamingStoreDB(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=GamingStoreDB;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Cateogory> Cateogories { get; set; }
        public virtual DbSet<Platform> Platforms { get; set; }

    }
}
