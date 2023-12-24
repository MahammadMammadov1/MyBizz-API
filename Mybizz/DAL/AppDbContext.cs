using Microsoft.EntityFrameworkCore;
using Mybizz.Configurations;
using Mybizz.Entities;

namespace Mybizz.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions contextOptions) : base(contextOptions) 
        {
            
        }

        public DbSet<Member> Members { get; set; }
        public DbSet<Profession> Professions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MemberConfiguration).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
