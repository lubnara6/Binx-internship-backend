# Cardiac Patient Monitoring API

ASP.NET Core Web API project developed as part of the Backend Training — Day 3.

The main focus of this day is **Integration Testing with WebApplicationFactory**.

## Technologies

* ASP.NET Core 8
* C#
* Entity Framework Core
* EF Core In-Memory Database
* xUnit
* WebApplicationFactory
* JWT Authentication
* Swagger

## Project Structure

```text
Day3
├── CardiacPatientMonitoring.Api
│   ├── Controllers
│   ├── Data
│   ├── Models
│   ├── Repositories
│   ├── Services
│   └── Program.cs
│
└── CardiacPatientMonitoring.Tests
    └── PatientApiTests.cs
```

## API Features

* Get a patient by ID.
* Return `404 Not Found` when the patient does not exist.
* Store patient data using an EF Core In-Memory Database.
* Protect endpoints using JWT authentication.
* Test authenticated and unauthenticated requests.

## Integration Testing

The project uses `WebApplicationFactory<Program>` to run the API in memory and send HTTP requests using `HttpClient`.

The tests cover:

### Get Patient

* Existing patient → `200 OK`
* Non-existing patient → `404 Not Found`

### Protected Endpoint

* Without JWT token → `401 Unauthorized`
* With a valid JWT token → `200 OK`

## Test Results

```text
Passed: 12
Failed: 0
Skipped: 0
Total: 12
```

All integration tests are passing successfully.

## Run the API

```bash
cd CardiacPatientMonitoring.Api
dotnet run
```

## Run Tests

From the `Day3` folder:

```bash
dotnet test
```

## Day 3 Topics

This project demonstrates:

* Setting up `WebApplicationFactory`
* Testing real HTTP endpoints
* Using a separate In-Memory test database
* Testing HTTP status codes and response bodies
* Testing protected endpoints with JWT authentication
