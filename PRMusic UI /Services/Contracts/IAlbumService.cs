using PRMusic.Dto;

namespace PRMusic_UI.Services.Contracts

{
    public interface IAlbumService
    {
        Task<List<AlbumDto>> GetAlbums();

        Task<AlbumDto> GetAlbumById(Guid id);

        Task<AlbumDto> UpdateAlbum(AlbumDto album);

        Task<AlbumDto> DeleteAlbum(Guid id);

        Task<AlbumDto> CreateAlbum(AlbumDto album);


    }
}
