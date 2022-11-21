using PRMusic_UI.Services.Contracts;
using PRMusic.Dto;
using System.Net.Http.Json;

namespace PRMusic_UI.Services
{
    public class SongService : ISongService
    {
        private readonly HttpClient httpClient;
        public SongService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<SongDto>> GetSongs()
        {
            try
            {
                var test = await httpClient.GetAsync("api/Song");
                var songs = await test.Content.ReadFromJsonAsync<List<SongDto>>();
                //var albums = await this.httpClient.GetFromJsonAsync<List<AlbumDto>>("api/Album");
                return songs;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<SongDto> GetSongById(Guid id)
        {
            try
            {
                var test = await httpClient.GetAsync($"api/Song/{id}");
                var songs = await test.Content.ReadFromJsonAsync<SongDto>();
                return songs;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<SongDto> UpdateSong(SongDto song)
        {
            if (song == null)
            {
                return null;

                //crear header
            }

            var test = await httpClient.PutAsJsonAsync("api/Song", song);
            var record = await test.Content.ReadFromJsonAsync<SongDto>();
            return record;
        }

        public async Task<SongDto> DeleteSong(Guid Id)
        {
            var test = await httpClient.DeleteAsync($"api/Song/{Id}");
            return null;
        }

        public async Task<SongDto> CreateSong(SongDto newSong)
        {
            var test = await httpClient.PostAsJsonAsync("api/Song", newSong);
            var record = await test.Content.ReadFromJsonAsync<SongDto>();
            return record;
        }


    }
}
