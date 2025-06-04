using Maentl.Models;
using Maentl.Repository;

namespace Maentl.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;

        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }

        public Task<IEnumerable<User>> GetAllUsersAsync() => _repo.GetAllAsync();
        public Task CreateUserAsync(User user) => _repo.CreateAsync(user);
    }
}
