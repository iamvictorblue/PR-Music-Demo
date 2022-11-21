using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using PRMusic.Dto;
using PRMusic.Interface;
namespace PRMusic.Repository

{
    public class PlaylistRepository : IPlaylistRepository
    {
        private readonly PRMusicContext _context;

        public PlaylistRepository(PRMusicContext context)
        {
            _context = context;
        }

        public async Task<List<PlaylistDto>> GetPlaylists()
        {
            var records = await _context
                .Playlists
                .Select(user =>
                new PlaylistDto
                {
                    Id = user.Id,
                    CreatedBy = user.CreatedBy,
                    CreatedAt = user.CreatedAt,
                    Followers = user.Followers
                    


                })
                .ToListAsync();

            return records;
        }

        public async Task<PlaylistDto> GetPlaylistById(Guid id)
        {
            var user = await _context.Playlists
                .Where(x => x.Id == id)
                .Select(user => new PlaylistDto
                {
                    Id = user.Id,
                    CreatedBy = user.CreatedBy,
                    CreatedAt = user.CreatedAt,
                    Followers = user.Followers



                })
                .FirstOrDefaultAsync();

            return user;

        }

        public async Task<PlaylistDto> UpdatePlaylist(PlaylistDto user)
        {
            var recordToUpdate = await _context.Playlists
               .Where(x => x.Id == user.Id)
               .Select(x => x)
               .FirstOrDefaultAsync();



            recordToUpdate.Followers = user.Followers;
            recordToUpdate.CreatedBy = user.CreatedBy;
            recordToUpdate.CreatedAt = user.CreatedAt;
            recordToUpdate.Id = user.Id;


            await _context.SaveChangesAsync();

            return new PlaylistDto
            {
                Id = user.Id,
                CreatedBy = user.CreatedBy,
                CreatedAt = user.CreatedAt,
                Followers = user.Followers

            };


        }

        public async Task<bool> DeletePlaylist(Guid id)
        {
            var recordToDelete = await _context
                .Playlists
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            _context.Playlists.Remove(recordToDelete);
            await _context.SaveChangesAsync();

            return true;
                
        }

        public async Task<PlaylistDto> AddPlaylist(PlaylistDto playlistRecord)
        {
            var newPlaylist = new Playlist
            {
                Id = Guid.NewGuid(),
                Followers = playlistRecord.Followers,
                CreatedBy = playlistRecord.CreatedBy,
                CreatedAt = playlistRecord.CreatedAt                

            };

            _context.Playlists.Add(newPlaylist);

            //var newSongs = new Song
            //{
            //    Id = Guid.NewGuid(),
            //    Genre = playlistRecord.Song.Genre,
            //    Album = playlistRecord.Song.Album,
            //    Artist = playlistRecord.Song.Artist,
            //    IsSingle = playlistRecord.Song.IsSingle,
            //    ReleaseDate = playlistRecord.Song.ReleaseDate,
            //    Title = playlistRecord.Song.Title
            //};

            //_context.Songs.Add(newSongs);

            //var playlistSongs = new PlaylistSong
            //{
            //    Id = Guid.NewGuid(),
            //    SongId = newSongs.Id,
            //    PlaylistId = newPlaylist.Id,

            //};

            //_context.PlaylistSongs.Add(playlistSongs);

            await _context.SaveChangesAsync();
            return playlistRecord;
        }




    }
}
