using Microsoft.EntityFrameworkCore;
using Auth.Domain.Interfaces.Repositories;
using Auth.Domain.Models;

namespace Auth.DataAccess.Repositories
{
    public class RefreshTokenRepository : IRefreshTokensRepository
    {
        private readonly UsersDbContext _context;

        public RefreshTokenRepository(UsersDbContext context)
        {
            _context = context;
        }

        public async Task Create(RefreshToken refreshToken)
        {
            await _context.RefreshTokens.AddAsync(refreshToken);
        }

        public async Task<RefreshToken> Get(string token) =>
            await _context.RefreshTokens.FirstOrDefaultAsync(rt => rt.Token == token);
        
    }
}
