using DTO;

namespace BL.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<UserDto> GetByEmailAsync(string email);
        Task<UserDto> CreateOrUpdateAsync(UserDto dto);
        Task<bool> DeactivateAsync(string email);
    }
}
