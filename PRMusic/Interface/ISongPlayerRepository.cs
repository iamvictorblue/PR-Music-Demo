using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using PRMusic.Dto;

namespace PRMusic.Interface
{
    public interface ISongPlayerRepository
    {
        Task<List<SongPlayerDto>> GetSongPlayers();

        Task<SongPlayerDto> GetSongPlayerById(Guid id);

        Task<SongPlayerDto> UpdateSongPlayer(SongPlayerDto user);

        Task<SongPlayer> CreateSongPlayer(SongPlayerDto user);

        Task<bool> DeleteSongPlayer(Guid id);


    }
}
