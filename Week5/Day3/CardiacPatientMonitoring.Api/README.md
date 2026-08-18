# Day 2 — Mocking Dependencies with Moq

## Overview

Day 2 focused on using **Moq** to isolate a service from its repository dependency during unit testing.

The Cardiac Patient Monitoring System uses `IPatientRepository` as an abstraction between the `PatientService` and the data access layer. Moq was used to create a mock implementation of this repository so the service could be tested without using a real database or repository.

## What Was Implemented

### 1. Repository Dependency

`PatientService` depends on `IPatientRepository` through dependency injection.

This allows the repository to be replaced with a mock during unit tests.

### 2. Moq Setup

A mock repository was created using:

```csharp
var mockRepository = new Mock<IPatientRepository>();
```

The mock was configured to return a specific patient when `GetByIdAsync()` is called.

### 3. Mocked Return Values

A test verifies that `GetPatientAsync()` correctly returns a patient provided by the mocked repository.

### 4. Mocked Exceptions

A test configures the repository to throw an exception and verifies that the service propagates the exception correctly.

### 5. Verify

Moq's `Verify()` method was used to confirm that the repository's `GetByIdAsync()` method was called exactly once.

## Unit Tests

The test project contains tests for:

* Normal heart rate validation.
* High heart rate validation.
* Low heart rate validation.
* Returning an existing patient using a mocked repository.
* Returning `null` when a patient does not exist.
* Handling a repository exception.
* Verifying repository interaction.

## Testing

The project was successfully built and all unit tests passed.

```text
Build succeeded.
0 Warning(s)
0 Error(s)

Passed: 8
Failed: 0
Skipped: 0
Total: 8
```

## Tools Used

* .NET 8
* xUnit
* Moq
* C#
* Visual Studio Code
* Git & GitHub

## Learning Outcome

This day demonstrated how mocking can isolate service logic from external dependencies and how Moq can be used to control return values, simulate exceptions, and verify interactions with dependencies.
