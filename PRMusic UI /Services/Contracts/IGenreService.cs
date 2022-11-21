using PRMusic.Dto;

namespace PRMusic_UI.Services.Contracts

{
    public interface IGenreService
    {
        Task<List<GenreDto>> GetGenres();

        Task<GenreDto> GetGenreById(Guid id);

        Task<GenreDto> UpdateGenre(GenreDto genre);

        Task<GenreDto> DeleteGenre(Guid id);

        Task<GenreDto> CreateGenre(GenreDto genre);
    }
}
