using PRMusic_UI.Services.Contracts;
using PRMusic.Dto;
using System.Net.Http.Json;

namespace PRMusic_UI.Services
{
    public class GenreService : IGenreService
    {
        private readonly HttpClient httpClient;
        public GenreService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<GenreDto>> GetGenres()
        {
            try
            {
                var test = await httpClient.GetAsync("api/Genre");
                var genres = await test.Content.ReadFromJsonAsync<List<GenreDto>>();              
                return genres;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<GenreDto> GetGenreById(Guid id)
        {
            try
            {
                var test = await httpClient.GetAsync($"api/Genre/{id}");
                var genres = await test.Content.ReadFromJsonAsync<GenreDto>();
                return genres;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<GenreDto> UpdateGenre(GenreDto genre)
        {
            if (genre == null)
            {
                return null;

                //crear header
            }

            var test = await httpClient.PutAsJsonAsync("api/Genre", genre);
            var record = await test.Content.ReadFromJsonAsync<GenreDto>();
            return record;
        }

        public async Task<GenreDto> DeleteGenre(Guid Id)
        {
            var test = await httpClient.DeleteAsync($"api/Genre/{Id}");
            return null;

        }
        public async Task<GenreDto> CreateGenre(GenreDto newGenre)
        {
            var test = await httpClient.PostAsJsonAsync("api/Playlist", newGenre);
            var record = await test.Content.ReadFromJsonAsync<GenreDto>();
            return record;
        }



    }
}
