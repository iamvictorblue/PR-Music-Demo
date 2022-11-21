using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PRMusic.Dto;
using PRMusic.Interface;
namespace PRMusic.Repository

{
    public class SongPlayerRepository : ISongPlayerRepository
    {
        private readonly PRMusicContext _context;

        public SongPlayerRepository(PRMusicContext context)
        {
            _context = context;
        }

        public async Task<List<SongPlayerDto>> GetSongPlayers()
        {
            var records = await _context
                .SongPlayers
                .Select(user =>
                new SongPlayerDto
                {
                    Id = user.Id,
                    UsersId = user.UsersId,
                    SongId = user.SongId,
                    ArtistId = user.ArtistId,
                    SongLength = user.SongLength,
                    StartTime = user.StartTime
                    


                })
                .ToListAsync();

            return records;
        }

        public async Task<SongPlayerDto> GetSongPlayerById(Guid id)
        {
            var user = await _context.SongPlayers
                .Where(x => x.Id == id)
                .Select(user => new SongPlayerDto
                {
                    Id = user.Id,
                    UsersId = user.UsersId,
                    SongId = user.SongId,
                    ArtistId = user.ArtistId,
                    SongLength = user.SongLength,
                    StartTime = user.StartTime

                })
                .FirstOrDefaultAsync();

            return user;

        }

        public async Task<SongPlayerDto> UpdateSongPlayer(SongPlayerDto user)
        {
            var recordToUpdate = await _context.SongPlayers
               .Where(x => x.Id == user.Id)
               .Select(x => x)
               .FirstOrDefaultAsync();



            recordToUpdate.Id = user.Id;
            recordToUpdate.SongId = user.SongId;
            recordToUpdate.ArtistId = user.ArtistId;
            recordToUpdate.SongLength = user.SongLength;
            recordToUpdate.StartTime = user.StartTime;
            recordToUpdate.UsersId = user.UsersId;


            await _context.SaveChangesAsync();

            return new SongPlayerDto
            {
                Id = user.Id,
                UsersId = user.UsersId,
                SongId = user.SongId,
                ArtistId = user.ArtistId,
                SongLength = user.SongLength,
                StartTime = user.StartTime
            };


        }

        public async Task<SongPlayer> CreateSongPlayer(SongPlayerDto user)
        {
            var newSongPlayer = new SongPlayer
            {
                Id = Guid.NewGuid(),
                UsersId = user.UsersId,
                SongId = user.SongId,
                ArtistId = user.ArtistId,
                SongLength = user.SongLength,
                StartTime = user.StartTime

            };

            _context.SongPlayers.Add(newSongPlayer);
            await _context.SaveChangesAsync();

            return newSongPlayer;


        }

        public async Task<bool> DeleteSongPlayer(Guid id)
        {
            var recordToDelete = await _context
                .SongPlayers
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            _context.SongPlayers.Remove(recordToDelete);
            await _context.SaveChangesAsync();

            return true;

        }
    }
}

