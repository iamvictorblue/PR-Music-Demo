using PRMusic_UI.Services.Contracts;
using PRMusic.Dto;
using System.Net.Http.Json;

namespace PRMusic_UI.Services
{
    public class UploadService : IUploadService
    {
        private readonly HttpClient httpClient;
        public UploadService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<UploadDto>> GetUploads()
        {
            try
            {
                var test = await httpClient.GetAsync("api/Upload");
                var uploads = await test.Content.ReadFromJsonAsync<List<UploadDto>>();
                //var albums = await this.httpClient.GetFromJsonAsync<List<AlbumDto>>("api/Album");
                return uploads;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<UploadDto> GetUploadById(Guid id)
        {
            try
            {
                var test = await httpClient.GetAsync($"api/Upload/{id}");
                var uploads = await test.Content.ReadFromJsonAsync<UploadDto>();
                return uploads;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<UploadDto> UpdateUpload(UploadDto upload)
        {
            if (upload == null)
            {
                return null;

                //crear header
            }

            var test = await httpClient.PutAsJsonAsync("api/Upload", upload);
            var record = await test.Content.ReadFromJsonAsync<UploadDto>();
            return record;
        }

        public async Task<UploadDto> DeleteUpload(Guid Id)
        {
            var test = await httpClient.DeleteAsync($"api/Upload/{Id}");
            return null;
        }

        public async Task<UploadDto> CreateUpload(UploadDto newUpload)
        {
            var test = await httpClient.PostAsJsonAsync("api/Upload", newUpload);
            var record = await test.Content.ReadFromJsonAsync<UploadDto>();
            return record;
        }


    }
}
