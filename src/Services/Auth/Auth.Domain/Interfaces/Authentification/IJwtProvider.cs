using Auth.Domain.Models;

namespace Auth.Domain.Interfaces.Authentification
{
    public interface IJwtProvider
    {
        string GenerateJwtToken(User user);
        string GenerateRefreshToken();
    }
}