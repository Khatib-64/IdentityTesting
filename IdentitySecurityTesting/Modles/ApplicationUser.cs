using Microsoft.AspNetCore.Identity;

namespace IdentitySecurityTesting.Modles;

public class ApplicationUser : IdentityUser
{
    public string Name { get; set; } = default!;
}
