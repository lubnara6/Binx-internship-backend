# MyFirstApi

## Description

MyFirstApi is an ASP.NET Core Web API project developed during backend training.

The project was built step by step while learning ASP.NET Core concepts and applying each concept directly to the same API project.

The project started with basic API endpoints and was gradually extended with controllers, Minimal APIs, middleware, dependency injection, services, Entity Framework Core, SQL Server, database migrations, and ASP.NET Core Identity.

---

## Technologies

- C#
- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- ASP.NET Core Identity
- Swagger
- Postman
- Visual Studio Code
- .NET CLI

---

# API Development

## Controllers

A controller-based API was created using `ItemsController`.

### Endpoints

| Method | Endpoint | Description |
|---|---|---|
| GET | `/api/items` | Get all items |
| GET | `/api/items/{id}` | Get an item by ID |

The controller uses:

- `ControllerBase`
- `[ApiController]`
- `[Route]`
- `[HttpGet]`
- `IActionResult`
- HTTP status codes such as `200 OK` and `404 Not Found`

---

## Minimal APIs

Minimal API endpoints were also created to understand the difference between controller-based APIs and Minimal APIs.

### Products

| Method | Endpoint | Description |
|---|---|---|
| GET | `/products` | Get all products |
| GET | `/products/{id}` | Get a product by ID |

The project uses `Results.Ok()` and `Results.NotFound()` for appropriate responses.

---

# Swagger

Swagger was added to the project for API documentation and testing.

The project uses:

```csharp
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();