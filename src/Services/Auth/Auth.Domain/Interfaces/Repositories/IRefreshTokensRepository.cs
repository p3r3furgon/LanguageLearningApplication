using System;
using Auth.Domain.Models;

namespace Auth.Domain.Interfaces.Repositories
{
    public interface IRefreshTokensRepository
    {
        Task<RefreshToken> Get(string refreshToken);
        Task Create(RefreshToken refreshToken);
    }
}
