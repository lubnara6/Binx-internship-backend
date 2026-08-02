# Day 1 – REST API Design Principles & Resource Modeling

## Overview

This document presents the REST API design for a simple **Library Management System**.  
The goal is to apply RESTful design principles, proper resource naming conventions, correct HTTP status codes, and API versioning.

---

# Project Domain

**Library Management System**

---

# Core Resources

The API is built around the following resources (plural nouns):

- Books
- Authors
- Members
- Shelves

---

# Primary Resource: Books

## Endpoints

| HTTP Method | Endpoint | Description |
|-------------|----------|-------------|
| GET | `/api/v1/books` | Retrieve all books |
| GET | `/api/v1/books/{id}` | Retrieve a specific book |
| POST | `/api/v1/books` | Create a new book |
| PUT | `/api/v1/books/{id}` | Update an existing book |
| DELETE | `/api/v1/books/{id}` | Delete a book |

---

# Nested Resource

Since an author can own multiple books, the following nested endpoint represents this relationship:

| HTTP Method | Endpoint | Description |
|-------------|----------|-------------|
| GET | `/api/v1/authors/{id}/books` | Retrieve all books written by a specific author |

---

# HTTP Status Codes

| Endpoint | Success Response | Example Error Response |
|----------|------------------|------------------------|
| GET `/api/v1/books` | **200 OK** | **404 Not Found** |
| GET `/api/v1/books/{id}` | **200 OK** | **404 Not Found** |
| POST `/api/v1/books` | **201 Created** | **400 Bad Request** |
| PUT `/api/v1/books/{id}` | **200 OK** | **404 Not Found** |
| DELETE `/api/v1/books/{id}` | **204 No Content** | **404 Not Found** |

---

# API Versioning

This project uses **URL Versioning**.

Current version:

```
/api/v1/books
```

Future versions may be introduced as:

```
/api/v2/books
```

This approach allows new API versions to be released without breaking existing clients.

---

# REST Design Principles

- Resources are represented using **plural nouns**.
- HTTP methods define the requested operation.
- URLs do not contain verbs such as `getBooks` or `createBook`.
- Appropriate HTTP status codes are returned for every request.
- The API follows a stateless REST architecture.
- Versioning is implemented through the URL.

---

# Example Requests

## Get All Books

**Request**

```http
GET /api/v1/books
```

**Response**

```http
200 OK
```

---

## Get Book by ID

**Request**

```http
GET /api/v1/books/1
```

**Response**

```http
200 OK
```

---

## Create a New Book

**Request**

```http
POST /api/v1/books
```

**Response**

```http
201 Created
```

---

## Update a Book

**Request**

http
PUT /api/v1/books/1
```

**Response**

```http
200 OK
```

---

## Delete a Book

**Request**

```http
DELETE /api/v1/books/1
```

**Response**

http
204 No Content


---

# Conclusion

This REST resource map demonstrates:

- RESTful resource modeling
- Consistent endpoint naming
- Proper HTTP status code usage
- Nested resource relationships
- API versioning strategy

These principles provide a clean, maintainable, and scalable API design.