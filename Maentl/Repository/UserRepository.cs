using Maentl.Data;
using Maentl.Models;
using Microsoft.EntityFrameworkCore;

namespace Maentl.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MaentlDbContext _context;

        public UserRepository(MaentlDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task CreateAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }
    }
}
