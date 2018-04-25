# Multi-Solution EF Core Migrations Test Playground

This repository contains a set of .NET Core Solutions with their own respective projects to showcase and allow screwing around with a mutli-solution, multi-project, build-out of EF Core with EF Core Migrations in-use, targeting SQLLite as the DB provider.

## How to use this code

Below are the steps that can be run to use this code in the simplest manner possible.
I would recommend just doing these steps in order to learn how things are working at a very basic level.
Then modify things like the Student Model, re-run migrations, apply new migrations, and watch what happens.

### Preparing Solutions for use

These commands are simply to clone this source and build each solution included using the .NET Core CLI. I've included them so you don't have to type all this yourself. If you don't understand these commmands, you should pause and go read up on the dotnet CLI tools.

```PowerShell
git clone git@github.com:justingarfield/MultiSolutionEFMigrationsTest.git
cd MultiSolutionEFMigrationsTest
dotnet restore DataSolution\DataProject
dotnet restore MigrationsSolution\MigrationsProject
dotnet restore WebApiSolution\WebApiProject
dotnet build .\DataSolution\DataSolution.sln
dotnet build .\MigrationsSolution\MigrationsSolution.sln
dotnet build .\WebApiSolution\WebApiSolution.sln
```

### Generating initial migration

These commands are how you generate your migrations, passing the WebAPI Project as a startup project to the migrations tooling.

```PowerShell
cd MigrationsSolution\MigrationsProject
dotnet ef migrations --startup-project ..\..\WebApiSolution\WebApiProject\WebApiProject.csproj add IntialMigration
```

### Applying migrations

These commands are how you apply your current migrations to the database utilized by the WebAPI project. This will differ in most environment as to how the Startup Project provides a connection string to the underlying DbContext, but this at least demonstrates a working example of how to apply them at the most basic level.

```PowerShell
cd MigrationsSolution\MigrationsProject
dotnet ef database update --startup-project ..\..\WebApiSolution\WebApiProject\WebApiProject.csproj
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
