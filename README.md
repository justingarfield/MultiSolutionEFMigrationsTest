# Multi-Solution EF Core Migrations Test Playground

This repository contains a set of .NET Core Solutions with their own respective projects to showcase and allow screwing around with a mutli-solution, multi-project, build-out of EF Core with EF Core Migrations in-use, targeting SQL Server as the DB provider.

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
