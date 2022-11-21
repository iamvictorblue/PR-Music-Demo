using PRMusic.Dto;

namespace PRMusic_UI.Services.Contracts

{
    public interface IUserService
    {
        Task<List<UserDto>> GetUsers();
        
        Task<UserDto> GetUserById(Guid id);

        Task<UserDto> UpdateUser(UserDto user);

        Task<UserDto> DeleteUser(Guid id);

        Task<UserDto> CreateUser(UserDto user);
    }
}
