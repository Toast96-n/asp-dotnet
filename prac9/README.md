# Employee Leave Management

The Employees pages use Entity Framework Core Code First with MySQL. The
initial migration creates an `Employees` table with an auto-increment ID and
required name, address, department, and contact fields.

## Configure and run

This project targets .NET 10 and uses Oracle's EF Core MySQL provider. Ensure
the MySQL server is running, then from this directory install the EF packages
and tooling if needed:

```powershell
dotnet add package MySql.EntityFrameworkCore --version 10.0.9
dotnet add package Microsoft.EntityFrameworkCore.Design --version 10.0.9
dotnet tool install --global dotnet-ef --version 10.0.9
```

The default connection settings in `appsettings.json` assume MySQL is running
locally on port 3306 with the `root` account. Keep the database password out of
source control; for local development, set the full connection string using
User Secrets (replace the placeholder with your MySQL password):

```powershell
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=localhost;Port=3306;Database=EmployeeLeaveDb;User ID=root;Password=YOUR_PASSWORD"
```

The initial migration is included in `Data/Migrations`. Apply it and run the app:

```powershell
dotnet ef database update
dotnet run
```

Open `/Employee/Employees` to add, view, edit, or delete employee records.
Verify saved rows in MySQL Workbench or with:

```sql
SELECT Id, Name, Address, Department, Contact
FROM Employees;
```

For future schema changes, update the model and run
`dotnet ef migrations add <MigrationName>` followed by
`dotnet ef database update`.
