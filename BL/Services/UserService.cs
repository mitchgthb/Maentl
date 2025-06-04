using BL.Interfaces;
using DTO;
using Maentl.SQL.Repository.Users;

namespace BL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;

        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await _repo.GetAllAsync();
            return users.Select(u => new UserDto
            {
                Id = u.Id,
                Email = u.Email,
                DisplayName = u.DisplayName,
                Role = u.Role
            });
        }

        public Task<UserDto> GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> CreateOrUpdateAsync(UserDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeactivateAsync(string email)
        {
            throw new NotImplementedException();
        }
    }
}
