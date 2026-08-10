## Day 2 — JWT Authentication & Token Issuance

- Learned the structure of JWT and its Header, Payload, and Signature.
- Learned about JWT claims.
- Implemented a login endpoint using `SignInManager`.
- Generated a JWT after successful login.
- Added user ID and email as JWT claims.
- Configured JWT Bearer Authentication.
- Configured JWT Issuer, Audience, and Signing Key.
- Set JWT token expiration.
- Protected an API endpoint using `[Authorize]`.
- Tested the endpoint without a token and received `401 Unauthorized`.
- Tested the endpoint with a valid Bearer Token and received `200 OK`.
- Decoded the JWT and verified its claims and expiration.
- Tested the authentication flow using Postman.