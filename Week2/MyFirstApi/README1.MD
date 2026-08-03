#  Library Management API – Day 3

##  Overview

This project demonstrates the setup of Entity Framework Core with SQL Server using the Code-First approach.

The database schema is based on the Library Management System designed in Day 2.

---

##  Technologies

- ASP.NET Core 8
- Entity Framework Core 8
- SQL Server Express
- SQL Server Management Studio (SSMS)

---

##  Project Structure

- Entities
  - Author
  - Book
  - LibraryMember
  - Employee
  - Loan

- Data
  - AppDbContext

- Migrations

---

##  Database Tables

- Authors
- Books
- Employees
- LibraryMembers
- Loans

---

##  Relationships

- One Author can have many Books.
- One Library Member can have many Loans.
- One Book can appear in many Loans.

---

##  Features Completed

- Created entity classes.
- Configured Entity Framework Core.
- Added DbContext.
- Connected to SQL Server.
- Generated the initial migration.
- Applied the migration.
- Created the database using Code-First.

---

##  Commands Used

```bash
dotnet ef migrations add InitialCreate

dotnet ef database update
```

---

## Database Preview

Database created successfully in SQL Server with all required tables.
