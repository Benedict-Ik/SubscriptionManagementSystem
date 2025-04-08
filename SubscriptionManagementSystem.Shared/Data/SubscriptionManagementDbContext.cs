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
            // Add custom model configuration here if needed.
        }
    }
}
