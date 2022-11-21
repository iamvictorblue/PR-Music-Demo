using DataLayer.Entities;
using PRMusic.Dto;

namespace PRMusic.Interface
{
    public interface IAlbumRepository
    { 
        Task<List<AlbumDto>> GetAlbums();

        Task<AlbumDto> GetAlbumById(Guid id);

        Task<AlbumDto> UpdateAlbum(AlbumDto user);

        Task<bool> DeleteAlbum(Guid id);

        Task<Album> AddAlbum(AlbumDto albumRecord);
    }

}
