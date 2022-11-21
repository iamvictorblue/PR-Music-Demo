using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using PRMusic.Dto;
using PRMusic.Interface;
namespace PRMusic.Repository

{
    public class ArtistRepository : IArtistRepository
    {
        private readonly PRMusicContext _context;

        public ArtistRepository(PRMusicContext context)
        {
            _context = context;
        }

        public async Task<List<ArtistDto>> GetArtists()
        {
            var records = await _context
                .Artists
                .Select(user =>
                new ArtistDto
                {
                    Id = user.Id,                   
                    ArtistName = user.ArtistName,
                    About = user.About,
                    CreatedBy = user.CreatedBy,
                    CreatedAt = user.CreatedAt
                    
                   
                })
                .ToListAsync();

            return records;
        }

        public async Task<ArtistDto> GetArtistById(Guid id)
        {
            var user = await _context.Artists
                .Where(x => x.Id == id)
                .Select(user => new ArtistDto
                {
                    Id = user.Id,
                    ArtistName = user.ArtistName,
                    About = user.About,
                    CreatedBy = user.CreatedBy,
                    CreatedAt = user.CreatedAt



                })
                .FirstOrDefaultAsync();

            return user;

        }

        public async Task<ArtistDto> UpdateArtist(ArtistDto user)
        {
            var recordToUpdate = await _context.Artists
               .Where(x => x.Id == user.Id)
               .Select(x => x)
               .FirstOrDefaultAsync();



            recordToUpdate.Id = user.Id;
            recordToUpdate.CreatedBy = user.CreatedBy;
            recordToUpdate.CreatedAt = user.CreatedAt;
            recordToUpdate.About = user.About;
            recordToUpdate.ArtistName = user.ArtistName;


            _context.SaveChangesAsync();

            return new ArtistDto
            {
                Id = user.Id,
                ArtistName = user.ArtistName,
                About = user.About,
                CreatedBy = user.CreatedBy,
                CreatedAt = user.CreatedAt

            };


        }

        public async Task<Artist> CreateArtist(ArtistDto user)
        {
            var newArtist = new Artist
            {
                Id = Guid.NewGuid(),
                CreatedAt = user.CreatedAt,
                CreatedBy = user.CreatedBy,
                ArtistName = user.ArtistName,
                About = user.About
            };
            _context.Artists.Add(newArtist);
            await _context.SaveChangesAsync();
            return newArtist;

        }

        public async Task<bool> DeleteArtist(Guid id)
        {
            var recordToDelete = await _context
                .Artists
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            _context.Artists.Remove(recordToDelete);
            await _context.SaveChangesAsync();

            return true;

        }




    }
}
