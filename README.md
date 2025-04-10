# Subscription Management System 

Here is what we did in this branch:

- To run migrations in a solution with multiple projects, we'll need to make a couple changes/configurations unlike the normal convention of a solution with a single project.
- We started off by modifying the User, Payment and Subscription model classes by mainly explicitly declaring and adding the `[EmailAddress]` and `[ForeignKey]` attributes.
- Modified the DbContext, SubscriptionManagementDbContext, onModelCreating as seen below:
```C#
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<Payment>()
        .Property(p => p.Amount)
        .HasPrecision(10, 2);

    modelBuilder.Entity<Plan>()
        .Property(p => p.Price)
        .HasPrecision(10, 2);
}
```

- This will ensure SQL Server stores these decimal values properly.
- Added a new folder called `Data` in the API project.
- Added a Design-Time Factory file called `SubscriptionManagementDbContextFactory` in the API project, which is embedded in the newly created `Data` folder, and is used to instantiate your DbContext at design time (for migrations), with the below code:
```C#
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
```
- Run the Migrations (from the Package Manager Console) with the commands below:
```bash
Add-Migration InitialCreate -Project SubscriptionManagementSystem.Shared -StartupProject SubscriptionManagementSystemAPI -OutputDir Migrations
Update-Database -Project SubscriptionManagementSystem.Shared -StartupProject SubscriptionManagementSystemAPI
```
> Make sure the `Default Project` is set to `SubscriptionManagementSystem.Shared` in the Package Manager Console, which is where the DbContext lives.  

> If you run into an error when running any of the above commands, specifically an error relating to `Modelbuilder`, go ahead an install the packages: `Microsoft.EntityFrameworkCore.Design`, `Microsoft.EntityFrameworkCore.SqlServer`, and `Microsoft.EntityFrameworkCore.Relational` in your shared project. Also ensure it is of the same version with the other EF related packages you have installed. Then rebuild the solution, delete Migration project and re-run the commands.  

- Now your migrations should run successfully.