using PRMusic.Dto;

namespace PRMusic_UI.Services.Contracts

{
    public interface ISongService
    {
        Task<List<SongDto>> GetSongs();

        Task<SongDto> GetSongById(Guid id);

        Task<SongDto> UpdateSong(SongDto song);

        Task<SongDto> DeleteSong(Guid id);

        Task<SongDto> CreateSong(SongDto song);
    }
}
