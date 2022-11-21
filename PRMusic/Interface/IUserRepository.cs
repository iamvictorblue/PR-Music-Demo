using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using PRMusic.Dto;

namespace PRMusic.Interface
{
    public interface IUserRepository
    {
        Task<List<UserDto>> GetUsers();


        Task<UserDto> GetUserById(Guid id);


        Task<UserDto> UpdateUser(UserDto user);

        Task<bool> DeleteUser(Guid id);

        Task<User> CreateUser(UserDto user);
     }
}
