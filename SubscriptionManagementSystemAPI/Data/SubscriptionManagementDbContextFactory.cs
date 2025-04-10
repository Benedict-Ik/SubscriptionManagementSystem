using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SubscriptionManagementSystem.Shared.Data;

namespace SubscriptionManagementSystemAPI.Data
{
    public class SubscriptionManagementDbContextFactory : IDesignTimeDbContextFactory<SubscriptionManagementDbContext>
    {
        public SubscriptionManagementDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<SubscriptionManagementDbContext>();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connectionString);

            return new SubscriptionManagementDbContext(optionsBuilder.Options);
        }
    }
}
