using System;
using System.Collections.Generic;

namespace DataLayer.Entities
{
    public partial class Artist
    {
        public Artist()
        {
            AlbumArtists = new HashSet<AlbumArtist>();
            SongPlayers = new HashSet<SongPlayer>();
        }

        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public string ArtistName { get; set; }
        public string? About { get; set; } 
        public virtual User? CreatedByNavigation { get; set; }
        public virtual ICollection<AlbumArtist> AlbumArtists { get; set; }
        public virtual ICollection<SongPlayer> SongPlayers { get; set; }
    }
}
