namespace PRMusic.Dto
{
    public class PlaylistDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public int Followers { get; set; }

        public SongDto? Song { get; set; }
    }
}
