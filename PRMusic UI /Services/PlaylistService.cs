using PRMusic_UI.Services.Contracts;
using PRMusic.Dto;
using System.Net.Http.Json;

namespace PRMusic_UI.Services
{
    public class PlaylistService : IPlaylistService
    {
        private readonly HttpClient httpClient;
        public PlaylistService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<PlaylistDto>> GetPlaylists()
        {
            try
            {
                var test = await httpClient.GetAsync("api/Playlist");
                var playlists = await test.Content.ReadFromJsonAsync<List<PlaylistDto>>();
                //var albums = await this.httpClient.GetFromJsonAsync<List<AlbumDto>>("api/Album");
                return playlists;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<PlaylistDto> GetPlaylistById(Guid id)
        {
            try
            {
                var test = await httpClient.GetAsync($"api/Playlist/{id}");
                var playlists = await test.Content.ReadFromJsonAsync<PlaylistDto>();
                return playlists;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<PlaylistDto> UpdatePlaylist(PlaylistDto playlist)
        {
            if (playlist == null)
            {
                return null;

                //crear header
            }

            var test = await httpClient.PutAsJsonAsync("api/Playlist", playlist);
            var record = await test.Content.ReadFromJsonAsync<PlaylistDto>();
            return record;
        }

        public async Task<PlaylistDto> DeletePlaylist(Guid Id)
        {
            var test = await httpClient.DeleteAsync($"api/Playlist/{Id}");
            return null;
        }

        public async Task<PlaylistDto> CreatePlaylist(PlaylistDto newPlaylist)
        {
            var test = await httpClient.PostAsJsonAsync("api/Playlist", newPlaylist);
            var record = await test.Content.ReadFromJsonAsync<PlaylistDto>();
            return record;
        }


    }
}
