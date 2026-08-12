# Hands-On Lab: Add Validators to Existing Endpoints

## Overview

This lab adds **FluentValidation** to the existing ASP.NET Core API to validate incoming requests before they reach the endpoint logic.

The goal is to ensure that invalid data is rejected automatically with a structured **400 Bad Request** response containing clear validation error messages.

## Objectives

* Install and configure FluentValidation.
* Create a validator for the Create request model.
* Create a validator for the Update request model.
* Apply real business validation rules.
* Register validators with ASP.NET Core.
* Verify automatic validation responses.
* Test each validation rule individually using Postman.

## Technologies Used

* ASP.NET Core Web API
* C#
* FluentValidation
* Swagger
* Postman

## Implementation

### 1. Install FluentValidation

FluentValidation and its ASP.NET Core integration package were added to the project.

The validators are registered so that incoming requests are validated automatically before the endpoint processes them.

### 2. Create Request Validator

A validator was created for the Create request model.

The validation rules cover real business requirements, such as:

* Required fields must not be empty.
* Text values must satisfy the required length or format.
* Numeric values must be within the allowed business range.

Example structure:

```csharp
public class CreateRequestValidator : AbstractValidator<CreateRequest>
{
    public CreateRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required.");

        RuleFor(x => x.Name)
            .MaximumLength(100)
            .WithMessage("Name must not exceed 100 characters.");

        RuleFor(x => x.Price)
            .GreaterThan(0)
            .WithMessage("Price must be greater than 0.");
    }
}
```

> The exact rules should match the business requirements of the existing project.

### 3. Update Request Validator

A separate validator was created for the Update request model.

The validator ensures that updated data follows the same business requirements and prevents invalid values from reaching the update endpoint.

```csharp
public class UpdateRequestValidator : AbstractValidator<UpdateRequest>
{
    public UpdateRequestValidator()
    {
        // Validation rules for the update request
    }
}
```

### 4. Register Validators

The validators were registered in the ASP.NET Core application so FluentValidation can automatically validate incoming requests.

Once registered, invalid requests are rejected before the controller action continues.

### 5. Validation Response

When a request fails validation, the API returns:

```http
400 Bad Request
```

The response contains structured validation errors, including the affected field and its corresponding error message.

Example:

```json
{
  "errors": {
    "Name": [
      "Name is required."
    ]
  }
}
```

## Postman Testing

Each validation rule was tested individually using Postman.

### Create Endpoint

The following cases were tested:

| Test Case             | Expected Result     |
| --------------------- | ------------------- |
| Empty required field  | 400 Bad Request     |
| Invalid text length   | 400 Bad Request     |
| Invalid numeric value | 400 Bad Request     |
| Valid request         | Successful response |

### Update Endpoint

The Update endpoint was also tested with invalid and valid request bodies to confirm that the validator is applied correctly.

## Result

The existing API endpoints now validate incoming Create and Update requests automatically.

Invalid requests return a structured **400 Bad Request** response with specific validation messages, while valid requests continue to the endpoint normally.

This improves the API by keeping validation rules separate from controller logic and making the endpoints easier to maintain and test.
