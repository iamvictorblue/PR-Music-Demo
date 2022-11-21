namespace PRMusic.Dto
{
    public class ArtistDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public string ArtistName { get; set; }         
        public string? About { get; set; } 
        public AlbumDto? Album { get; set; }
    }
}
