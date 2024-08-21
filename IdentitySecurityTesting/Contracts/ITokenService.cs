using IdentitySecurityTesting.Modles;
using IdentitySecurityTesting.Modles.Dtos;

namespace IdentitySecurityTesting.Contracts;

public interface ITokenService
{
    Task<string> GenerateJwtTokenAsync(TokenRequest request);
}

public class TokenRequest
{
    public string Password { get; set; } = default!;
    public string Email { get; set; } = default!;
}
