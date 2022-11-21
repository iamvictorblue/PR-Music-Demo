using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using PRMusic.Dto;
using PRMusic.Interface;
namespace PRMusic.Repository

{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly PRMusicContext _context;

        public AlbumRepository(PRMusicContext context)
        {
            _context = context;
        }

        public async Task<List<AlbumDto>> GetAlbums()
        {
            var records = await _context
                .Albums
                .Select(user =>
                new AlbumDto
                {
                    Id = user.Id,
                    Genre = user.Genre,
                    AlbumLength = user.AlbumLength,
                    ReleaseDate = user.ReleaseDate, 
                    IsSingle = user.IsSingle,   
                    SongId = user.SongId,
                    CreatedBy = user.CreatedBy,
                    Songs = new SongDto {
                        Id = user.Song.Id,
                        Genre = user.Song.Genre,
                        CreatedBy = user.Song.CreatedBy,
                        Album = user.Song.Album,
                        Artist = user.Song.Artist,
                        CreatedAt = user.Song.CreatedAt,
                        IsSingle = user.Song.IsSingle,
                        ReleaseDate = user.Song.ReleaseDate,
                        Title = user.Song.Title
                    }

                })
                .ToListAsync();

            return records;
        }

        public async Task<AlbumDto> GetAlbumById(Guid id)
        {
            var user = await _context.Albums
                .Where(x => x.Id == id)
                .Select(user => new AlbumDto
                {
                    Id = user.Id,
                    Genre = user.Genre,
                    AlbumLength = user.AlbumLength,
                    ReleaseDate = user.ReleaseDate,
                    IsSingle = user.IsSingle,
                    SongId = user.SongId,                  
                    CreatedBy = user.CreatedBy

                })
                .FirstOrDefaultAsync();

            return user;

        }

        public async Task<AlbumDto> UpdateAlbum(AlbumDto user)
        {
            var recordToUpdate = await _context.Albums
               .Where(x => x.Id == user.Id)
               .Select(x => x)
               .FirstOrDefaultAsync();

            recordToUpdate.Genre = user.Genre;
            recordToUpdate.ReleaseDate = user.ReleaseDate;
            recordToUpdate.SongId = user.SongId;
            recordToUpdate.CreatedBy = user.CreatedBy;
            recordToUpdate.AlbumLength = user.AlbumLength;
            recordToUpdate.IsSingle = user.IsSingle;

            await _context.SaveChangesAsync();

            return new AlbumDto
            {
                Id = user.Id,
                Genre = user.Genre,
                AlbumLength = user.AlbumLength,
                ReleaseDate = user.ReleaseDate,
                IsSingle = user.IsSingle,
                SongId = user.SongId,
                CreatedBy = user.CreatedBy
            };


        }

        public async Task<Album> AddAlbum(AlbumDto albumRecord)
        {
            var newAlbum = new Album
            {
                Id = Guid.NewGuid(),
                Genre = albumRecord.Genre,
                AlbumLength = albumRecord.AlbumLength,
                ReleaseDate = albumRecord.ReleaseDate,
                IsSingle = albumRecord.IsSingle,
                SongId = albumRecord.SongId,
                CreatedBy = albumRecord.CreatedBy
            };
            _context.Albums.Add(newAlbum);
            

            //var newGenre = new Genre
            //{
            //    Id = Guid.NewGuid(),
            //    CreatedBy = albumRecord.CreatedBy,
            //    Name = albumRecord.Genre
                
            //};

            //_context.Genres.Add(newGenre);

            //var albumGenre = new AlbumGenre
            //{
            //    Id = Guid.NewGuid(),
            //    CreatedBy = albumRecord.CreatedBy,
            //    GenreId = newGenre.Id,
            //    SongId = albumRecord.SongId,
            //    AlbumId = newAlbum.Id

            //};

            //_context.AlbumGenres.Add(albumGenre);

            //  var newArtist = new Artist
            //{
            //    Id = Guid.NewGuid(),              
                

            //};

            //_context.Artists.Add(newArtist);

            //var albumArtist = new AlbumArtist
            //{
            //    ArtistId = newArtist.Id,
            //    AlbumId = newAlbum.Id,
            //    Id = Guid.NewGuid()
            //};

            //_context.AlbumArtists.Add(albumArtist);

            //var albumUpload = new Upload
            //{
            //    Id = Guid.NewGuid(),
            //    UsersId = albumRecord.CreatedBy
                
               

            //};
            //_context.Uploads.Add(albumUpload);

            await _context.SaveChangesAsync();
            return newAlbum;
        }

        public async Task<bool> DeleteAlbum(Guid id)
        {
            var recordToDelete = await _context
                .Albums
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            _context.Albums.Remove(recordToDelete);
            await _context.SaveChangesAsync();

            return true;

        }


    }
}
