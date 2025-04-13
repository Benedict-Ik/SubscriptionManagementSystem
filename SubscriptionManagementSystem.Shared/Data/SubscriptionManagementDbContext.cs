using Microsoft.EntityFrameworkCore;
using SubscriptionManagementSystem.Shared.Models.Domain;

namespace SubscriptionManagementSystem.Shared.Data
{
    public class SubscriptionManagementDbContext : DbContext
    {
        public SubscriptionManagementDbContext(DbContextOptions<SubscriptionManagementDbContext> options)
            : base(options)
        {
        }

        // DbSets for each entity (Model classes)
        public DbSet<User> Users { get; set; }
        public DbSet<ExternalLogin> ExternalLogins { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Set precision for decimal columns
            modelBuilder.Entity<Payment>()
                .Property(p => p.Amount)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Plan>()
                .Property(p => p.Price)
                .HasPrecision(10, 2);

            // Configure foreign key from Payments to Users to avoid cascade path conflict
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.User)
                .WithMany(u => u.Payments)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.NoAction); // 👈 Prevent cascade delete from Users to Payments

            // Configure foreign key from Payments to Subscriptions
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Subscription)
                .WithMany(s => s.Payments)
                .HasForeignKey(p => p.SubscriptionId)
                .OnDelete(DeleteBehavior.Cascade); // 👈 Allow cascade if needed (no conflict expected)
        }

    }
}