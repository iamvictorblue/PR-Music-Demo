using PRMusic_UI.Services.Contracts;
using PRMusic.Dto;
using System.Net.Http.Json;

namespace PRMusic_UI.Services
{
    public class SongPlayerService : ISongPlayerService
    {
        private readonly HttpClient httpClient;
        public SongPlayerService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<SongPlayerDto>> GetSongPlayers()
        {
            try
            {
                var test = await httpClient.GetAsync("api/SongPlayer");
                var songplayers = await test.Content.ReadFromJsonAsync<List<SongPlayerDto>>();
                //var albums = await this.httpClient.GetFromJsonAsync<List<AlbumDto>>("api/Album");
                return songplayers;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<SongPlayerDto> GetSongPlayerById(Guid id)
        {
            try
            {
                var test = await httpClient.GetAsync($"api/SongPlayer/{id}");
                var playlists = await test.Content.ReadFromJsonAsync<SongPlayerDto>();
                return playlists;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<SongPlayerDto> UpdateSongPlayer(SongPlayerDto songplayer)
        {
            if  (songplayer == null)
            {
                return null;

                //crear header
            }

            var test = await httpClient.PutAsJsonAsync("api/SongPlayer", songplayer);
            var record = await test.Content.ReadFromJsonAsync<SongPlayerDto>();
            return record;
        }

        public async Task<SongPlayerDto> DeleteSongPlayer(Guid Id)
        {
            var test = await httpClient.DeleteAsync($"api/SongPlayer/{Id}");
            return null;
        }

        public async Task<SongPlayerDto> CreateSongPlayer(SongPlayerDto newSongPlayer)
        {
            var test = await httpClient.PostAsJsonAsync("api/SongPlayer", newSongPlayer);
            var record = await test.Content.ReadFromJsonAsync<SongPlayerDto>();
            return record;
        }


    }
}
