# Week 3 Summary

## Overview

During Week 3, I focused on building and testing a complete RESTful API using ASP.NET Core, Entity Framework Core, and SQL Server. The main objective was to implement full CRUD operations for the Books resource, connect the API to the database, and verify all endpoints using Postman.

---

## CRUD Implementation

I successfully implemented all CRUD operations for the Books resource:

### Create Book
- Created a POST endpoint to add a new book.
- Received data using a CreateBookRequest DTO.
- Mapped the DTO to the Book entity.
- Saved the new book to the SQL Server database using Entity Framework Core.

### Get All Books
- Implemented a GET endpoint to retrieve all books from the database.
- Returned the complete list of available books.

### Get Book By Id
- Implemented a GET endpoint to retrieve a specific book using its ID.
- Returned a 404 Not Found response when the requested book did not exist.

### Update Book
- Implemented a PUT endpoint to update an existing book.
- Updated only the required fields.
- Returned 404 when attempting to update a non-existing book.

### Delete Book
- Implemented a DELETE endpoint to remove a book from the database.
- Returned 204 No Content after a successful deletion.
- Returned 404 Not Found when trying to delete a book that does not exist.

---

## Database Integration

- Connected the project to SQL Server using Entity Framework Core.
- Used AppDbContext for database operations.
- Stored and retrieved data directly from the database instead of using in-memory collections.

---

## API Testing with Postman

To verify the API functionality, I created a dedicated Postman Collection that contains all endpoints.

The collection includes:

- Create Book
- Get All Books
- Get Book By Id
- Update Book
- Delete Book

Both successful and error scenarios were tested.

### Happy Path Tests
Verified that all endpoints returned the expected successful responses.

Examples:
- Create Book → 200 OK
- Get All Books → 200 OK
- Update Book → 200 OK
- Delete Book → 204 No Content

### Error Path Tests
Verified that the API correctly handles invalid requests.

Examples:
- Get Book By Invalid Id → 404 Not Found
- Delete Non-existing Book → 404 Not Found

---

## Automated Postman Tests

Added Postman Post-response test scripts to automatically validate API responses.

Examples include:

- Checking that GET requests return status code 200.
- Checking that DELETE requests return status code 204.
- Checking successful Create requests.

This allows requests to be automatically validated instead of manually checking every response.

---

## Postman Environment

Created a Postman Environment named **Local**.

Added a reusable variable:

- `baseUrl = http://localhost:5286`

Updated all requests to use:

```
{{baseUrl}}/api/books
```

instead of hardcoding the server address, making the collection portable and easier to reuse.

---

## Skills Practiced

Throughout this week, I practiced:

- ASP.NET Core Web API
- REST API Design
- Entity Framework Core
- SQL Server Integration
- CRUD Operations
- DTO Design
- Dependency Injection
- HTTP Status Codes
- API Testing using Postman
- Postman Collections
- Postman Environments
- Automated Postman Test Scripts

---

## Outcome

By the end of Week 3, I successfully built a fully functional REST API for managing books, connected it to SQL Server, implemented complete CRUD functionality, organized and tested the API using Postman, added automated test scripts, and prepared the project for future deployment and mentor review.