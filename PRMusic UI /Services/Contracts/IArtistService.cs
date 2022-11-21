using PRMusic.Dto;

namespace PRMusic_UI.Services.Contracts

{
    public interface IArtistService
    {
        Task<List<ArtistDto>> GetArtists();
       
        Task<ArtistDto> GetArtistById(Guid id);

        Task<ArtistDto> UpdateArtist(ArtistDto artist);

        Task<ArtistDto> DeleteArtist(Guid id);

        Task<ArtistDto> CreateArtist(ArtistDto artist);
    }
}
