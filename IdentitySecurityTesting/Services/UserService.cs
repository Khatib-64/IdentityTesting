
using IdentitySecurityTesting.Modles;
using IdentitySecurityTesting.Modles.Dtos;
using Microsoft.AspNetCore.Identity;

namespace IdentitySecurityTesting.Contracts;

public class UserService : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UserService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<ApplicationUserDto> CreateAsync(CreateUserRequest request)
    {
        var applicationUser = new ApplicationUser()
        {
            Name = request.Name,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            UserName = request.UserName,
        };

        var createUserResult = await _userManager.CreateAsync(applicationUser, request.Password);

        if (createUserResult.Succeeded)
        {
            return new ApplicationUserDto()
            {
                Email = applicationUser.Email,
                Name = applicationUser.Name,
                PhoneNumber = applicationUser.PhoneNumber,
                UserName = applicationUser.UserName,
            };
        }

        throw new ArgumentException(createUserResult.ToString());
    }
}
