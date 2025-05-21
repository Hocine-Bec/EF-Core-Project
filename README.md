# EF Core Project

## Overview

This repository contains a comprehensive learning project that implements an educational institution's course management system using Entity Framework Core. The project was developed while following an in-depth course on EF Core, serving as both a reference implementation and a practical learning tool for mastering Entity Framework Core concepts and best practices.

> **Note:** This repository uses commit history to document the learning journey. Each commit represents a specific EF Core concept or technique learned, allowing you to follow the progression from basic to advanced implementation. The latest commit represents the final state after completing all lessons.

## Learning Journey & Features Implemented

Throughout this project, I explored and implemented the following EF Core concepts:

### Core EF Concepts
- **Code-First Approach**: Built domain models first and generated the database from them
- **Database First/Scaffolding**: Learned how to reverse-engineer models from existing databases
- **Migrations**: Managed database schema evolution through code-based migrations
- **DbContext Configuration**: Properly configured the DbContext as the entry point to the database

### Entity Modeling & Relationships
- **Complex Domain Modeling**: Created a comprehensive educational domain model
- **Fluent API Configurations**: Used explicit configurations over annotations for better control
- **Relationship Mapping**: Implemented one-to-one, one-to-many, and many-to-many relationships
- **Composite Keys**: Defined entities with keys composed of multiple fields
- **Owned Entity Types**: Implemented value objects as owned entities (e.g., TimeSlot)
- **Table/Column Mapping**: Explicitly mapped entities to tables and properties to columns

### Advanced Data Management
- **Query Performance Optimization**: Progressed from basic to highly optimized queries
- **Eager, Lazy, and Explicit Loading**: Implemented different data loading strategies
- **Query Filtration**: Applied various filtering techniques to retrieve specific data
- **Global Query Filters**: Implemented automatic filtering for entities
- **Pagination**: Built efficient paging mechanisms for large datasets
- **Transactions**: Managed database transactions for data integrity
- **Soft Delete**: Implemented logical deletion instead of physical records removal
- **Value Conversions**: Used HasConversion to transform data between entity and database

## System Architecture

The project implements a simple folder architecture with:

- **Domain Folder**: Contains the entity classes representing the educational domain model
- **Data Access Folder**: Manages database access through Entity Framework Core
- **Program.cs**: Provides the entry point to the system

## Domain Model

The project models an educational institution's course management system
- *Entity Relationship Diagram of the Educational Institution Data Model*

![Project Diagram](https://github.com/Hocine-Bec/EF-Core-Project/blob/main/Images/Project%20Diagram%20v1.svg)


## Key Implementation Features

### Entity Configuration

The project employs Entity Framework Core's Fluent API for explicit configuration of entity properties and relationships:

| Configuration Feature | Description | Example |
| --- | --- | --- |
| Table Mapping | Maps entities to specific database tables | `ToTable("Courses")` |
| Property Configuration | Configures column types, lengths, and precision | `HasMaxLength(255).HasColumnType("VARCHAR")` |
| Relationship Mapping | Defines relationships between entities | `HasOne(...).WithMany(...)` |
| Composite Keys | Defines keys composed of multiple fields | `HasKey("SectionId", "StudentId")` |
| Owned Entity Types | Configures value objects as owned entities | `OwnsOne("TimeSlot")` |
| Value Conversions | Transforms data between entity and database | `HasConversion<string>()` |

### Time Management with TimeSlot

A notable feature is the `TimeSlot` owned entity that manages start and end times for sections, demonstrating EF Core's support for complex value objects.

### Schedule System

The schedule system uses boolean flags to represent days of the week, providing a flexible way to define recurring schedules, showcasing efficient representation of complex scheduling patterns.

## Performance Optimization

The project demonstrates a progression of query techniques:
- Basic LINQ queries
- Optimized queries with proper includes
- Performance comparison between different loading strategies
- Implementation of pagination for handling large datasets
- Index configuration for performance optimization

## Data Access Patterns

Throughout the project, several data access patterns are implemented:
- Repository Pattern
- Unit of Work
- Query Objects
- Specification Pattern

## Getting Started

### Prerequisites
- .NET Core 6.0 or later
- SQL Server (LocalDB, Express, or full edition)

### Setup
1. Clone the repository
2. Update the connection string in `appsettings.json` if needed
3. Run EF Core migrations with `dotnet ef database update`
4. Launch the application with `dotnet run`

### Exploring the Learning Journey
To explore the project's evolution:
1. Review the commit history to see the progression of EF Core concepts
2. Check out specific commits to see the implementation at different learning stages
3. Compare commits to understand how the code evolved as new concepts were introduced
   ```
   git checkout <commit-hash>  # To view the code at a specific learning stage
   ```

## Learning Resources

This project was created while following a comprehensive EF Core course covering everything from basic to advanced concepts. The implementation showcases best practices for entity configuration, relationship mapping, database schema management, and performance optimization.

## Conclusion

This EF Core Project serves as both a reference implementation and a learning tool for anyone interested in understanding how to effectively use Entity Framework Core in real-world applications. It demonstrates the progression from simple database operations to complex, optimized data access patterns.

[![Ask DeepWiki](https://deepwiki.com/badge.svg)](https://deepwiki.com/Hocine-Bec/EF-Core-Project)
