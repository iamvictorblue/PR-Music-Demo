using DataLayer.Entities;
using PRMusic.Dto;

namespace PRMusic.Interface
{
    public interface IArtistRepository
    {
        Task<List<ArtistDto>> GetArtists();

        Task<ArtistDto> GetArtistById(Guid id);

        Task<ArtistDto> UpdateArtist(ArtistDto user);

        Task <bool> DeleteArtist(Guid id);

        Task<Artist> CreateArtist(ArtistDto user);

    }

}
