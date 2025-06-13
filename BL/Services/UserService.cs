using BL.Interfaces;
using DTO;
using Enums;
using Maentl.SQL.Model;
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
                Role = u.Role,
                IsActive = u.IsActive
            });
        }

        public async Task<UserDto> GetByEmailAsync(string email)
        {
            var user = await _repo.GetByEmailAsync(email);
            if (user == null) return null;

            return new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                DisplayName = user.DisplayName,
                Role = user.Role,
                IsActive = user.IsActive
            };
        }

        public async Task<UserDto> CreateOrUpdateAsync(UserDto dto)
        {
            var existing = await _repo.GetByEmailAsync(dto.Email);
            if (existing == null)
            {
                var newUser = new User
                {
                    Email = dto.Email,
                    DisplayName = dto.DisplayName,
                    Role = dto.Role,
                    IsActive = true
                };
                await _repo.CreateAsync(newUser);
                dto.Id = newUser.Id;
            }
            else
            {
                existing.DisplayName = dto.DisplayName;
                existing.Role = dto.Role;
                await _repo.UpdateAsync(existing);
                dto.Id = existing.Id;
            }

            return dto;
        }

        public async Task<bool> DeactivateAsync(string email)
        {
            var user = await _repo.GetByEmailAsync(email);
            if (user == null) return false;

            user.IsActive = false;
            await _repo.UpdateAsync(user);
            return true;
        }
    }
}
