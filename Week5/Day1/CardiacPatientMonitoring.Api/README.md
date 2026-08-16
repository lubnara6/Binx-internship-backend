# Day 1 — Phase 3 Project & Unit Testing

## Project Selection

**Chosen Project:** Cardiac Patient Monitoring System

## Unit Testing

An xUnit test project was created and referenced to the Cardiac Patient Monitoring API project.

The tests follow the **Arrange-Act-Assert (AAA)** pattern:

* **Arrange:** Prepare the object and test data.
* **Act:** Execute the method being tested.
* **Assert:** Verify that the result matches the expected behavior.

### Fact Tests

Three `[Fact]` tests were implemented for the `IsHeartRateNormal` service method:

1. Verify that a normal heart rate returns `true`.
2. Verify that a high heart rate of `120` returns `false`.
3. Verify that a low heart rate of `40` returns `false`.

### Theory Test

A `[Theory]` test was implemented using three input cases:

* `60` → `true`
* `80` → `true`
* `120` → `false`

This demonstrates how one test method can verify multiple related scenarios using `[InlineData]`.

## Test Result

All tests passed successfully:

```text
Passed: 7
Failed: 0
Skipped: 0
Total: 7
```
## Project Scope

The Cardiac Patient Monitoring System is an ASP.NET Core REST API for managing patient profiles, vital-sign measurements, medications, and appointments. The project will apply the backend concepts covered during the training, including C#, ASP.NET Core, Entity Framework Core, SQL Server, authentication, validation, error handling, and automated testing. The project is appropriately scoped to be completed by Week 9 while delivering the required professional baseline with a maintainable and documented backend structure.

The project is therefore ready to continue to the next Phase 3 development requirements.
