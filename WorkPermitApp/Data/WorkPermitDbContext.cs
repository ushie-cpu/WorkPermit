using Microsoft.EntityFrameworkCore;
using WorkPermitApp.Models;

namespace WorkPermitApp.Data
{
    public class WorkPermitDbContext : DbContext
    {
        public WorkPermitDbContext(DbContextOptions<WorkPermitDbContext> options)
            : base(options)
        {
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<WorkPermit> WorkPermits { get; set; }
        public DbSet<SiteChecker> SiteCheckers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WorkPermit>()
                .HasOne(w => w.AppUser)
                .WithMany(u => u.WorkPermits)
                .HasForeignKey(w => w.AppUserId);

            modelBuilder.Entity<WorkPermit>()
                .HasOne(w => w.SiteChecker)
                .WithOne(s => s.WorkPermit)
                .HasForeignKey<SiteChecker>(s => s.WorkPermitId);
        }
    }

}
