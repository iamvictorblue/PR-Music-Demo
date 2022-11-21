using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using PRMusic.Dto;

namespace PRMusic.Interface
{
    public interface IGenreRepository
    {
        Task<List<GenreDto>> GetGenres();

        Task<GenreDto> GetGenreById(Guid id);

        Task<GenreDto> UpdateGenre(GenreDto user);

        Task<bool> DeleteGenre(Guid id);

        Task<Genre> CreateGenre(GenreDto user);
    }

}
