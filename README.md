# EF-Core-Project

## Introduction

This project serves as a comprehensive exploration of Entity Framework Core (EF Core), developed as part of a course to understand and implement various features of EF Core. It encompasses a progression from basic to advanced concepts, including migrations, scaffolding, code-first approach, configurations, transactions, query filters, owned entities, and more.

## Project Structure

The project is organized as follows:

- `Entities/` – Contains the entity classes representing the database tables.
- `Data/` – Includes the `DbContext` class and configurations.
- `Migrations/` – Holds the EF Core migration files.
- `Interfaces/` – Defines interfaces for repositories and services.
- `Enums/` – Contains enumeration types used across the project.
- `Program.cs` – The main entry point of the application.
- `appsettings.json` – Configuration file for application settings.
- `db_script.sql` – SQL script for initializing the database schema.

## Learning Progression

The project reflects a chronological learning path through EF Core concepts:

### 1. Initial Setup and Basic Migrations

- Established the project structure and initial entity models.
- Implemented initial migrations to create the database schema.

### 2. Advanced Migrations and Schema Evolution

- Added new entities and relationships.
- Performed migrations to update the database schema accordingly.

### 3. Implementing Soft Delete Functionality

- Created an `ISoftDelete` interface to mark entities as soft-deletable.
- Developed a `SoftDeleteInterceptor` to intercept delete operations and mark entities as deleted without removing them from the database.
- Applied global query filters to exclude soft-deleted entities from query results.

### 4. Query Enhancements

- Utilized raw SQL queries for complex data retrieval scenarios to improve performance.
- Implemented pagination to efficiently handle large datasets.
- Explored LINQ methods like `SelectMany` for flattening collections.
- Applied grouping and aggregate functions to perform statistical analyses.

### 5. Advanced Configurations

- Configured owned entities to encapsulate related data within a single entity.
- Set up transactions to ensure data consistency across multiple operations.

## Features

- Code-first approach using EF Core.
- Comprehensive use of migrations for database schema management.
- Implementation of soft delete pattern with global query filters.
- Advanced querying techniques including raw SQL, pagination, and aggregation.
- Configuration of owned entities and transaction management.

## Dependencies

- .NET 6.0 SDK or later
- Entity Framework Core
- SQL Server([learn.microsoft.com](https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/projects?utm_source=chatgpt.com "Using a Separate Migrations Project - EF Core | Microsoft Learn"))

## Configuration

Update the `appsettings.json` file with your database connection string:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=EFCoreDb;Trusted_Connection=True;"
  }
}
```


[![Ask DeepWiki](https://deepwiki.com/badge.svg)](https://deepwiki.com/Hocine-Bec/EF-Core-Project)