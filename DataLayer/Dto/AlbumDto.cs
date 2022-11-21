namespace PRMusic.Dto
{
    public class AlbumDto
    {
        public Guid Id { get; set; }
        public Guid CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }
        public string Genre { get; set; }
        public TimeSpan AlbumLength { get; set; }
        public DateTime ReleaseDate { get; set; }
        public bool IsSingle { get; set; }
        public Guid SongId { get; set; }   

       // public UploadDto? Upload { get; set; }

        public SongDto? Songs {  get; set; }  

    }
}
