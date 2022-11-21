namespace PRMusic.Dto
{
    public class GenreDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public string Name { get; set; } 
    }
}
