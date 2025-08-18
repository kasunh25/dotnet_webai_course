using Microsoft.AspNetCore.Identity;

namespace NET8API.Repositories
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);

    }
}
