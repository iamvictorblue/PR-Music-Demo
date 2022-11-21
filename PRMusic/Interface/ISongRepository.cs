using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using PRMusic.Dto;

namespace PRMusic.Interface
{
    public interface ISongRepository
    {
        Task<List<SongDto>> GetSongs();

        Task<SongDto> GetSongById(Guid id);

        Task<SongDto> UpdateSong(SongDto user);

        Task<bool> DeleteSong(Guid id);

       

        Task<SongDto> AddSong(SongDto songRecord);
    }

}
