# Day 2 - SQL Server Schema Design & Normalization

## Objective

Design a normalized database schema for a Library Management System by applying database normalization principles and defining relationships between entities.

---

## Entities

### Authors
- AuthorId (PK)
- AuthorName
- Email

### Books
- BookId (PK)
- Title
- Price
- AuthorId (FK)

### Members
- MemberId (PK)
- Name
- Phone
- Email
- Address

### Employees
- EmployeeId (PK)
- Name
- Phone
- Email
- Position

### Loans
- LoanId (PK)
- BookId (FK)
- MemberId (FK)
- LoanDate
- ReturnDate
- Status

---

## Normalization

### First Normal Form (1NF)
- Each column contains atomic values.
- No repeating groups or multiple values in a single field.

### Second Normal Form (2NF)
- All non-key attributes depend on the entire primary key.

### Third Normal Form (3NF)
- Related data is stored in separate tables.
- Author information is stored in the Authors table instead of Books to avoid redundancy.

---

## Relationships

- One Author can write many Books.
- One Member can have many Loans.
- One Book can appear in many Loan records over time.

---

## Primary Keys

- AuthorId
- BookId
- MemberId
- EmployeeId
- LoanId

---

## Foreign Keys

- Books.AuthorId → Authors.AuthorId
- Loans.BookId → Books.BookId
- Loans.MemberId → Members.MemberId

---

## Data Types

| Column | Type |
|--------|------|
| Id | int |
| Name | nvarchar(100) |
| Title | nvarchar(150) |
| Email | nvarchar(100) |
| Phone | nvarchar(20) |
| Address | nvarchar(200) |
| Price | decimal(10,2) |
| LoanDate | datetime |
| ReturnDate | datetime |
| Status | nvarchar(20) |

---

## ERD

See **ERD.png** for the complete Entity Relationship Diagram.