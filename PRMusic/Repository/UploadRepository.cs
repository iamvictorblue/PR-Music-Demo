using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PRMusic.Dto;
using PRMusic.Interface;
namespace PRMusic.Repository

{
    public class UploadRepository : IUploadRepository
    {
        private readonly PRMusicContext _context;

        public UploadRepository(PRMusicContext context)
        {
            _context = context;
        }

        public async Task<List<UploadDto>> GetUploads()
        {
            var records = await _context
                .Uploads
                .Select(user =>
                new UploadDto
                {
                    Id = user.Id,
                    CreatedAt = user.CreatedAt,
                    CreatedBy = user.CreatedBy,                  
                    SongId = user.SongId,
                    UsersId = user.UsersId
                })
                .ToListAsync();

            return records;
        }

        public async Task<UploadDto> GetUploadById(Guid id)
        {
            var user = await _context.Uploads
                .Where(x => x.Id == id)
                .Select(user => new UploadDto
                {
                    Id = user.Id,
                    CreatedAt = user.CreatedAt,
                    CreatedBy = user.CreatedBy,
                    SongId = user.SongId,
                    UsersId = user.UsersId



                })
                .FirstOrDefaultAsync();

            return user;

        }

        public async Task<UploadDto> UpdateUpload(UploadDto user)
        {
            var recordToUpdate = await _context.Uploads
               .Where(x => x.Id == user.Id)
               .Select(x => x)
               .FirstOrDefaultAsync();



            recordToUpdate.Id = user.Id;
            recordToUpdate.UsersId = user.UsersId;
            recordToUpdate.CreatedBy = user.CreatedBy;
            recordToUpdate.SongId = user.SongId;
            recordToUpdate.CreatedAt = user.CreatedAt;


            await _context.SaveChangesAsync();

            return new UploadDto
            {
                Id = user.Id,
                CreatedAt = user.CreatedAt,
                CreatedBy = user.CreatedBy,
                SongId = user.SongId,
                UsersId = user.UsersId

            };


        }

        public async Task<Upload> CreateUpload(UploadDto user)
        {
            var newUpload = new Upload
            {
                Id = Guid.NewGuid(),
                UsersId = user.UsersId,
                SongId = user.SongId,
                CreatedAt = user.CreatedAt,
                CreatedBy = user.CreatedBy
                
            };

            _context.Uploads.Add(newUpload);
            await _context.SaveChangesAsync();

            return newUpload;

        }

        public async Task<bool> DeleteUpload(Guid id)
        {
            var recordToDelete = await _context
                .Uploads
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            _context.Uploads.Remove(recordToDelete);
            await _context.SaveChangesAsync();

            return true;

        }




    }
}
