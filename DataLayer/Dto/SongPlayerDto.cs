namespace PRMusic.Dto
{
    public class SongPlayerDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid CreatedBy { get; set; }

        public Guid CreatedAt { get; set; }
        public Guid UsersId { get; set; }
        public Guid SongId { get; set; }
        public Guid ArtistId { get; set; }
        public TimeSpan SongLength { get; set; }
        public TimeSpan StartTime { get; set; }

    }
}
