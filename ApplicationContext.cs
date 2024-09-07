using Microsoft.EntityFrameworkCore;

namespace MenuHierarchyApp
{
    public class ApplicationContext : DbContext
    {
        public DbSet<MenuItem> MenuItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MenuHierarchyDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MenuItem>()
                .HasOne(m => m.Parent)
                .WithMany(m => m.SubMenuItems)
                .HasForeignKey(m => m.ParentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
