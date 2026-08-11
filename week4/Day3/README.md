# Hands-On Lab: Protect Routes & Add Roles

## Overview

In this lab, I added authentication and authorization to the ASP.NET Core API.

The main goal was to protect the API endpoints using JWT tokens, create different user roles, restrict certain actions to admins, and configure Postman to use the JWT token automatically.

---

## 1. Protecting Routes with `[Authorize]`

I added the `[Authorize]` attribute to the `BooksController`.

This means that users cannot access the Books endpoints unless they provide a valid JWT token.

For example:

```csharp
[Authorize]
[Route("api/[controller]")]
public class BooksController : ControllerBase
```

I tested the endpoint without a token and confirmed that the API returns:

```text
401 Unauthorized
```

---

## 2. Creating User and Admin Roles

I configured ASP.NET Core Identity to support roles:

```csharp
builder.Services.AddIdentityCore<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddSignInManager()
    .AddEntityFrameworkStores<AppDbContext>();
```

Then I created two roles:

* `User`
* `Admin`

I also assigned the `Admin` role to the test user:

```text
test2@gmail.com
```

This allows the API to distinguish between normal users and administrators.

---

## 3. Restricting Admin Actions

The `Create` and `Delete` operations are restricted to users with the `Admin` role.

For example:

```csharp
[Authorize(Roles = "Admin")]
[HttpDelete("{id}")]
```

An Admin can perform the operation successfully.

A user without the required role receives:

```text
403 Forbidden
```

The difference is:

* `401` → No valid authentication/token.
* `403` → The user is authenticated but does not have permission.

---

## 4. Named Authorization Policy

I created a named authorization policy called `AdminOnly` in `Program.cs`:

```csharp
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy =>
    {
        policy.RequireRole("Admin");
    });
});
```

The policy is then applied to an endpoint:

```csharp
[Authorize(Policy = "AdminOnly")]
[HttpPost]
```

This makes the authorization rule reusable instead of putting the role requirement directly on every endpoint.

---

## 5. JWT Authentication

The API uses JWT Bearer Authentication.

The JWT configuration validates:

* Issuer
* Audience
* Token lifetime
* Signing key

The authentication middleware is enabled using:

```csharp
app.UseAuthentication();
app.UseAuthorization();
```

When a user logs in successfully, the API returns a JWT token.

Example login:

```http
POST /api/Auth/login
```

Request body:

```json
{
  "email": "test2@gmail.com",
  "password": "Test123!"
}
```

The response contains:

```json
{
  "token": "JWT_TOKEN"
}
```

---

## 6. Postman Environment

I created a Postman environment containing:

```text
baseUrl
token
```

The `baseUrl` stores the API URL:

```text
http://localhost:5286
```

The `token` variable stores the JWT returned from the login request.

I configured Postman to save the token automatically after login:

```javascript
const response = pm.response.json();

pm.environment.set("token", response.token);
```

Protected requests can then use:

```text
{{token}}
```

as the Bearer token.

---

## 7. Testing

The following cases were tested:

| Test                              | Expected Result    |
| --------------------------------- | ------------------ |
| Request without token             | `401 Unauthorized` |
| Valid Admin token                 | Request succeeds   |
| User token on Admin-only endpoint | `403 Forbidden`    |
| Valid token on protected endpoint | `200 OK`           |
| Login with valid credentials      | JWT token returned |

---

## Result

The API is now protected using JWT authentication and role-based authorization.

The project supports:

* JWT authentication
* Protected routes
* User and Admin roles
* Admin-only operations
* Named authorization policies
* Automatic JWT handling in Postman

The final protected requests were successfully tested and returned `200 OK`.
