using IdentitySecurityTesting.Contracts;
using IdentitySecurityTesting.Modles;
using IdentitySecurityTesting.Modles.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentitySecurityTesting.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly ITokenService _tokenService;

    public UserController(IUserService userService, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ITokenService tokenService)
    {
        _userService = userService;
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenService = tokenService;
    }

    [HttpPost]
    public async Task<ApplicationUserDto> CreateAsync(CreateUserRequest request)
    {
        return await _userService.CreateAsync(request);
    }
    
    [HttpPost("login")]
    public async Task<string> GetTokenAsync(TokenRequest request)
    {
        return await _tokenService.GenerateJwtTokenAsync(request);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(CreateUserRequest model)
    {
        if (ModelState.IsValid)
        {
            var user = new ApplicationUser { UserName = model.Email, Email = model.Email, Name = model.Name, PhoneNumber = model.PhoneNumber };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                return Ok(new { Message = "Registration successful" });
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        return BadRequest(ModelState);
    }
}
