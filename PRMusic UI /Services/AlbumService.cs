using PRMusic_UI.Services.Contracts;
using PRMusic.Dto;
using System.Net.Http.Json;

namespace PRMusic_UI.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly HttpClient httpClient;
        public AlbumService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<AlbumDto>> GetAlbums()
        {
            try
            {
                var test = await httpClient.GetAsync("api/Album");
                var albums = await test.Content.ReadFromJsonAsync<List<AlbumDto>>();
                return albums;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<AlbumDto> GetAlbumById(Guid id)
        {
            try
            {
                var test = await httpClient.GetAsync($"api/Album/{id}");
                var albums = await test.Content.ReadFromJsonAsync<AlbumDto>();
                return albums;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<AlbumDto> UpdateAlbum(AlbumDto album)
        {
            if(album == null)
            {
                return null;

                //crear header
            }

            var test = await httpClient.PutAsJsonAsync("api/Album", album);
            var record = await test.Content.ReadFromJsonAsync<AlbumDto>();
            return record;
        }

        public async Task<AlbumDto> DeleteAlbum(Guid Id)
        {
            var test = await httpClient.DeleteAsync($"api/Album/{Id}");
            return null;
            
        }

        public async Task<AlbumDto> CreateAlbum(AlbumDto newAlbum)
        {
            var test = await httpClient.PostAsJsonAsync("api/Album", newAlbum);
            var record = await test.Content.ReadFromJsonAsync<AlbumDto>();
            return record;
        }

    }
}
