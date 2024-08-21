using IdentitySecurityTesting.Modles;
using IdentitySecurityTesting.Modles.Dtos;

namespace IdentitySecurityTesting.Contracts;

public interface IUserService
{
    Task<ApplicationUserDto> CreateAsync(CreateUserRequest request);
}


public class CreateUserRequest
{
    public string Name { get; set; } = default!;
    public string UserName { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
}
