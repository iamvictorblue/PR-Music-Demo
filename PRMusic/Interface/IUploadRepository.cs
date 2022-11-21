using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using PRMusic.Dto;

namespace PRMusic.Interface
{
    public interface IUploadRepository
    {
        Task<List<UploadDto>> GetUploads();

        Task<UploadDto> GetUploadById(Guid id);

        Task<UploadDto> UpdateUpload(UploadDto user);

        Task<bool> DeleteUpload(Guid id);

        Task<Upload> CreateUpload(UploadDto user);


    }
}
