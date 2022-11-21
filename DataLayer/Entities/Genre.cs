using System;
using System.Collections.Generic;

namespace DataLayer.Entities
{
    public partial class Genre
    {
        public Genre()
        {
            AlbumGenres = new HashSet<AlbumGenre>();
            SongGenres = new HashSet<SongGenre>();
        }

        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public string Name { get; set; } 

        public virtual User? CreatedByNavigation { get; set; }
        public virtual ICollection<AlbumGenre> AlbumGenres { get; set; }
        public virtual ICollection<SongGenre> SongGenres { get; set; }
    }
}
