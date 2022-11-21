using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using PRMusic.Dto;
using PRMusic.Interface;
namespace PRMusic.Repository

{
    public class GenreRepository : IGenreRepository
    {
        private readonly PRMusicContext _context;

        public GenreRepository(PRMusicContext context)
        {
            _context = context;
        }

        public async Task<List<GenreDto>> GetGenres()
        {
            var records = await _context
                .Genres
                .Select(user =>
                new GenreDto
                {
                    Id = user.Id,
                    Name = user.Name,
                    CreatedBy = user.CreatedBy,
                    CreatedAt = user.CreatedAt


                })
                .ToListAsync();

            return records;
        }

        public async Task<GenreDto> GetGenreById(Guid id)
        {
            var user = await _context.Genres
                .Where(x => x.Id == id)
                .Select(user => new GenreDto
                {
                    Id = user.Id,
                    Name = user.Name,
                    CreatedBy = user.CreatedBy,
                    CreatedAt = user.CreatedAt



                })
                .FirstOrDefaultAsync();

            return user;

        }

        public async Task<GenreDto> UpdateGenre(GenreDto user)
        {
            var recordToUpdate = await _context.Genres
               .Where(x => x.Id == user.Id)
               .Select(x => x)
               .FirstOrDefaultAsync();



            recordToUpdate.Id = user.Id;
            recordToUpdate.Name = user.Name;
            recordToUpdate.CreatedBy = user.CreatedBy;
            recordToUpdate.CreatedAt = user.CreatedAt;



            await _context.SaveChangesAsync();

            return new GenreDto
            {
                Id = user.Id,
                Name = user.Name,
                CreatedBy = user.CreatedBy,
                CreatedAt = user.CreatedAt
            };


        }
        public async Task<bool> DeleteGenre(Guid id)
        {
            var recordToDelete = await _context
                .Genres
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            _context.Genres.Remove(recordToDelete);
            await _context.SaveChangesAsync();

            return true;

        }

        public async Task<Genre> CreateGenre(GenreDto user)
        {
            var newGenre = new Genre
            {
                Id = Guid.NewGuid(),
                Name = user.Name,              
                CreatedBy = user.CreatedBy,
                CreatedAt = user.CreatedAt
            };

            _context.Genres.Add(newGenre);
            await _context.SaveChangesAsync();

            return newGenre;
        }




    }
}
