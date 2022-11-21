using PRMusic_UI.Services.Contracts;
using PRMusic.Dto;
using System.Net.Http.Json;

namespace PRMusic_UI.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient httpClient;
        public UserService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<UserDto>> GetUsers()
        {
            try
            {
                var test = await httpClient.GetAsync("api/User");
                var users = await test.Content.ReadFromJsonAsync<List<UserDto>>();
                //var albums = await this.httpClient.GetFromJsonAsync<List<AlbumDto>>("api/Album");
                return users;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<UserDto> GetUserById(Guid id)
        {
            try
            {
                var test = await httpClient.GetAsync($"api/User/{id}");
                var users = await test.Content.ReadFromJsonAsync<UserDto>();
                return users;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<UserDto> UpdateUser(UserDto user)
        {
            if (user == null)
            {
                return null;

                //crear header
            }

            var test = await httpClient.PutAsJsonAsync("api/User", user);
            var record = await test.Content.ReadFromJsonAsync<UserDto>();
            return record;
        }

        public async Task<UserDto> DeleteUser(Guid Id)
        {
                var test = await httpClient.DeleteAsync($"api/User/{Id}");               
                return null;          
        }

        public async Task<UserDto> CreateUser(UserDto newUser)
        {            
            var test = await httpClient.PostAsJsonAsync("api/User", newUser);
            var record = await test.Content.ReadFromJsonAsync<UserDto>();
            return record;
        }


    }
}
