using Maentl.Models;

namespace Maentl.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task CreateUserAsync(User user);
    }
}
