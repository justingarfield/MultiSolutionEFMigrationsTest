# Multi-Solution EF Core Migrations Test Playground

This repository contains a set of .NET Core Solutions with their own respective projects to showcase and allow screwing around with a mutli-solution, multi-project, build-out of EF Core with EF Core Migrations in-use, targeting SQLLite as the DB provider.

```PowerShell
git clone git@github.com:justingarfield/MultiSolutionEFMigrationsTest.git
cd MultiSolutionEFMigrationsTest
dotnet restore DataSolution\DataProject
dotnet restore MigrationsSolution\MigrationsProject
dotnet restore WebApiSolution\WebApiProject
```

```PowerShell
cd MigrationsSolution\MigrationsProject
dotnet ef migrations --startup-project ..\..\WebApiSolution\WebApiProject\WebApiProject.csproj add IntialMigration
```

## Useful Information

### IDesignTimeDbContextFactory / DbContext lookups

If you're attempting to find where the EF Core CLI Migrations command does the lookup for your IDesignTimeDbContextFactory or DbContext implementations, start by looking here at Line 121: https://github.com/aspnet/EntityFrameworkCore/blob/592be3047f8cf30ecac89f6fd4eca376a2bcc331/src/EFCore.Design/Design/Internal/DbContextOperations.cs#L121

### dotnet ef CLI source
If you're looking for the actual source code for the dotnet ef CLI tooling, it all starts right here: https://github.com/aspnet/EntityFrameworkCore/tree/592be3047f8cf30ecac89f6fd4eca376a2bcc331/src/dotnet-ef

### Related Reading and Resources

* [Using a Separate Project](https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/projects)
* [Design-time DbContext Creation](https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dbcontext-creation)
* [EF Core .NET Command-line Tools](https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet)
