using PRMusic.Dto;

namespace PRMusic_UI.Services.Contracts

{
    public interface IUploadService
    {
        Task<List<UploadDto>> GetUploads();

        Task<UploadDto> GetUploadById(Guid id);

        Task<UploadDto> UpdateUpload(UploadDto upload);

        Task<UploadDto> DeleteUpload(Guid id);

        Task<UploadDto> CreateUpload(UploadDto upload);
    }
}
