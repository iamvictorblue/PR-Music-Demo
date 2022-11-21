namespace PRMusic.Dto
{
    public class SongDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public string Title { get; set; } 
        public string Album { get; set; } 
        public string Artist { get; set; }
        public string Genre { get; set; } 
        public DateTime ReleaseDate { get; set; }
        public bool IsSingle { get; set; }

    }
}
