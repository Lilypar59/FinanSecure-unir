using FinanSecure.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanSecure.Api.Data
{
    public class FinanSecureContext : DbContext
    {
        public FinanSecureContext(DbContextOptions<FinanSecureContext> options)
            : base(options)
        {
        }

        public DbSet<Transaction> Transactions => Set<Transaction>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.ToTable("transactions");
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Type).IsRequired().HasMaxLength(20);
                entity.Property(t => t.Category).IsRequired().HasMaxLength(100);
                entity.Property(t => t.Description).HasMaxLength(255);
                entity.Property(t => t.Amount).HasColumnType("decimal(10,2)");
                entity.Property(t => t.Date).IsRequired();
            });
        }
    }
}
