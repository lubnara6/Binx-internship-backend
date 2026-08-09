using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyFirstApi.DTOs;

namespace MyFirstApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;

    public AuthController(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }
    [HttpPost("register")]
public async Task<IActionResult> Register(RegisterDto model)
{
    var user = new IdentityUser
    {
        UserName = model.Email,
        Email = model.Email
    };

    var result = await _userManager.CreateAsync(user, model.Password);

    if (!result.Succeeded)
    {
        return BadRequest(result.Errors);
    }

    return Ok(new
    {
        message = "User registered successfully"
    });
}
}