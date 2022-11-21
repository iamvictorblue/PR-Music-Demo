using PRMusic_UI.Services.Contracts;
using PRMusic.Dto;
using System.Net.Http.Json;

namespace PRMusic_UI.Services
{
    public class ArtistService : IArtistService
    {
        private readonly HttpClient httpClient;
        public ArtistService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<ArtistDto>> GetArtists()
        {
            try
            {
                var test = await httpClient.GetAsync("api/Artist");
                var artist = await test.Content.ReadFromJsonAsync<List<ArtistDto>>();
                //var albums = await this.httpClient.GetFromJsonAsync<List<AlbumDto>>("api/Album");
                return artist;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<ArtistDto> GetArtistById(Guid id)
        {
            try
            {
                var test = await httpClient.GetAsync($"api/Artist/{id}");
                var artists = await test.Content.ReadFromJsonAsync<ArtistDto>();
                return artists;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<ArtistDto> UpdateArtist(ArtistDto artist)
        {
            if (artist == null)
            {
                return null;

                //crear header
            }

            var test = await httpClient.PutAsJsonAsync("api/Artist", artist);
            var record = await test.Content.ReadFromJsonAsync<ArtistDto>();
            return record;
        }

        public async Task<ArtistDto> DeleteArtist(Guid Id)
        {
            var test = await httpClient.DeleteAsync($"api/Artist/{Id}");
            return null;

        }

        public async Task<ArtistDto> CreateArtist(ArtistDto newArtist)
        {
            var test = await httpClient.PostAsJsonAsync("api/Artist", newArtist);
            var record = await test.Content.ReadFromJsonAsync<ArtistDto>();
            return record;
        }





    }
}
