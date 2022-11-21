using PRMusic.Dto;

namespace PRMusic_UI.Services.Contracts

{
    public interface ISongPlayerService
    {
        Task<List<SongPlayerDto>> GetSongPlayers();

        Task<SongPlayerDto> GetSongPlayerById(Guid id);

        Task<SongPlayerDto> UpdateSongPlayer(SongPlayerDto songplayer);

        Task<SongPlayerDto> DeleteSongPlayer(Guid Id);

        Task<SongPlayerDto> CreateSongPlayer(SongPlayerDto songplayer);
    }
}
