using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using PRMusic.Dto;

namespace PRMusic.Interface
{
    public interface IPlaylistRepository
    {
        Task<List<PlaylistDto>> GetPlaylists();

        Task<PlaylistDto> GetPlaylistById(Guid id);

        Task<PlaylistDto> UpdatePlaylist(PlaylistDto user);

        Task<bool> DeletePlaylist(Guid id);

        Task<PlaylistDto> AddPlaylist(PlaylistDto user); 
     

    }
}
