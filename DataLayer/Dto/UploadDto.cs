namespace PRMusic.Dto
{
    public class UploadDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid UsersId { get; set; }
        public Guid SongId { get; set; }
  
    }
}
