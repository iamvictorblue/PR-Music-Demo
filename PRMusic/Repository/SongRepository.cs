using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PRMusic.Dto;
using PRMusic.Interface;
namespace PRMusic.Repository

{
    public class SongRepository : ISongRepository
    {
        private readonly PRMusicContext _context;

        public SongRepository(PRMusicContext context)
        {
            _context = context;
        }

        public async Task<List<SongDto>> GetSongs()
        {
            var records = await _context
                .Songs
                .Select(user =>
                new SongDto
                {
                    Id = user.Id,
                    Genre = user.Genre,
                    CreatedBy = user.CreatedBy,
                    Album = user.Album, 
                    Artist = user.Artist,   
                    CreatedAt = user.CreatedAt,
                    IsSingle = user.IsSingle,
                    ReleaseDate = user.ReleaseDate,
                    Title = user.Title
                    
                })
                .ToListAsync();

            return records;
        }

        public async Task<SongDto> GetSongById(Guid id)
        {
            var user = await _context.Songs
                .Where(x => x.Id == id)
                .Select(user => new SongDto
                {
                    Id = user.Id,
                    Genre = user.Genre,
                    CreatedBy = user.CreatedBy,
                    Album = user.Album,
                    Artist = user.Artist,
                    CreatedAt = user.CreatedAt,
                    IsSingle = user.IsSingle,
                    ReleaseDate = user.ReleaseDate,
                    Title = user.Title


                })
                .FirstOrDefaultAsync();

            return user;

        }

        public async Task<SongDto> UpdateSong(SongDto user)
        {
            var recordToUpdate = await _context.Songs
               .Where(x => x.Id == user.Id)
               .Select(x => x)
               .FirstOrDefaultAsync();



            recordToUpdate.Genre = user.Genre;
            recordToUpdate.ReleaseDate = user.ReleaseDate;
            recordToUpdate.Title = user.Title;
            recordToUpdate.Album = user.Album;
            recordToUpdate.Artist = user.Artist;
            recordToUpdate.CreatedAt = user.CreatedAt;
            recordToUpdate.IsSingle = user.IsSingle;
            recordToUpdate.CreatedBy = user.CreatedBy;
            recordToUpdate.Id = user.CreatedBy;


            _context.SaveChangesAsync();

            return new SongDto
            {
                Id = user.Id,
                Genre = user.Genre,
                CreatedBy = user.CreatedBy,
                Album = user.Album,
                Artist = user.Artist,
                CreatedAt = user.CreatedAt,
                IsSingle = user.IsSingle,
                ReleaseDate = user.ReleaseDate,
                Title = user.Title

            };


        }

       
        public async Task<bool> DeleteSong(Guid id)
        {
            var recordToDelete = await _context
                .Songs
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            _context.Songs.Remove(recordToDelete);
            await _context.SaveChangesAsync();

            return true;

        }

        public async Task<SongDto> AddSong(SongDto songRecord)
        {
            var newSong = new Song
            {
                Id = Guid.NewGuid(),
                CreatedBy = songRecord.CreatedBy,
                Title = songRecord.Title,
                Album = songRecord.Album,
                Artist = songRecord.Artist,
                Genre = songRecord.Genre,
                ReleaseDate = songRecord.ReleaseDate,
                IsSingle = songRecord.IsSingle

            };

            _context.Songs.Add(newSong);

            var newGenre = new Genre
            {
                Id = Guid.NewGuid(),
                CreatedBy = songRecord.CreatedBy,
                CreatedAt = songRecord.CreatedAt,
                Name = songRecord.Genre
            };

            _context.Genres.Add(newGenre);

            var songGenre = new SongGenre
            {
                Id = Guid.NewGuid(),
                SongId = newSong.Id,
                GenreId = newGenre.Id,
                CreatedAt = songRecord.CreatedAt,
                CreatedBy = songRecord.CreatedBy
               
            };
            _context.SongGenres.Add(songGenre);

            //var songUpload = new Upload
            //{
            //    Id = Guid.NewGuid(),
            //    UsersId = songRecord.CreatedBy,
            //    SongId = newSong.Id
            //};

            //_context.Uploads.Add(songUpload);
         
            await _context.SaveChangesAsync();
            return songRecord;
        }


    }
}        



