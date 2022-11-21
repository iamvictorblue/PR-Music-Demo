using System;
using System.Collections.Generic;

namespace DataLayer.Entities
{
    public partial class Album
    {
        public Album()
        {
            AlbumArtists = new HashSet<AlbumArtist>();
        }

        public Guid Id { get; set; }
        public Guid CreatedBy { get; set; }
        public string Genre { get; set; } 
        public TimeSpan AlbumLength { get; set; }
        public DateTime ReleaseDate { get; set; }
        public bool IsSingle { get; set; }
        public Guid SongId { get; set; }
       

        public virtual User? CreatedByNavigation { get; set; }
        public virtual Song Song { get; set; }
        public virtual ICollection<AlbumArtist> AlbumArtists { get; set; }
    }
}
