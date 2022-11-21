namespace PRMusic.Dto
{
    public class UserDto
    {
        public Guid Id { get; set; }
        
        public DateTime CreatedDate { get; set; }
               
        public Guid CreatedBy { get; set; }
        public Guid CreatedAt { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
