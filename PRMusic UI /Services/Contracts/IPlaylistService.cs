using PRMusic.Dto;

namespace PRMusic_UI.Services.Contracts

{
    public interface IPlaylistService
    {
        Task<List<PlaylistDto>> GetPlaylists();

        Task<PlaylistDto> GetPlaylistById(Guid id);

        Task<PlaylistDto> UpdatePlaylist(PlaylistDto playlist);

        Task<PlaylistDto> DeletePlaylist(Guid Id);

        Task<PlaylistDto> CreatePlaylist(PlaylistDto playlist);
    }
}
