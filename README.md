# Subscription Management System 

- Added a new folder called `Data` in our shared `SubscriptionManagementSystem.shared` project which will house our DbContext class any any other data related class.
- Created a new class called `SubscriptionManagementDbContext.cs` which will serve as the bridge between our project and the database with the help of a tool called Entity Framework (EF) Core.
- In order to use EF Core, the following packages have to be installed (via the Package Manager Console or by right-clicking on Dependencies > Manage Nuget Packages):
    - Microsoft.EntityFrameworkCore: For the core EF functionality.
    - Microsoft.EntityFrameworkCore.SqlServer (For SQL Server Databases): For interacting with SQL Server databases.
    - Microsoft.EntityFrameworkCore.Tools: For running migrations from the Package Manager Console.
    - Microsoft.EntityFrameworkCore.Design (optional): For design-time features like migrations and scaffolding. We won't use it here.
> If an error is thrown in any installation, ensure the versions installed corresponds with the version of your Dot Net running on your local. You may also need to pay attention to the 'Dependencies' section in each of these packages to ensure all is in order.
- I installed `EntityFrameworkCore` in the Shared project and `EntityFrameworkCore.SqlServer` and `EntityFrameworkCore.Tools` in the API project.
- In the newly created DbContext class, `SubscriptionManagementDbContext`, inherit the base DbContext class.
- Add a constructor that takes in DbContextOptions\<SubscriptionManagementDbContext>options and passes it to the base class.
- All entities with navigation properties (in the model classes) have corresponding DbSet\<T> declarations.
- Foreign Key properties in each entity follow standard naming conventions, allowing EF Core to automatically map the relationships.
- The absence of explicit configuration in OnModelCreating is acceptable because EF Core conventions will pick up the relationships from your model definitions.
- At this point, we created the database that will be used to store our tables and data.
- Open SSMS and create a new database called `SubscriptionManagementSystemDb`.
- Now, navigate to the `appsettings.json` file in the API project and add a connection string to the database we just created. The connection string should look like this:

```json
 "ConnectionStrings": {
    "DefaultConnection": "Server=<Server Name>;Database=<Database Name>;Trusted_Connection=True;TrustServerCertificate=true"
  }
```
    
- \<Server Name> is the name of your SQL Server instance. It is usually displayed as a pop up box for authentication once your SSMS is launched. 
  - If you are using a local instance, it might be something like `localhost` or `.\SQLEXPRESS`.
  - If you are using a remote server, it will be the name or IP address of that server.
  - If you are using Docker, it will be the name of the container running SQL Server.
- \<Database Name> is the name of the database just created.

- Next, I registered the `SubscriptionManagementDbContext` in the `Program.cs` file (within the API project) for dependency injection:

```C#
builder.Services.AddDbContext<SubscriptionManagementDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
```
> This line of code tells the ASP.NET Core dependency injection system to create an instance of `SubscriptionManagementDbContext` whenever it's needed, using the connection string defined in `appsettings.json`. The `UseSqlServer` method configures the context to use SQL Server as the database provider.
> You may have to add a reference to the `shared` project in the `Program.cs` file