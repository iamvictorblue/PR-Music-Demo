using System;
using System.Collections.Generic;

namespace DataLayer.Entities
{
    public partial class Playlist
    {
        public Playlist()
        {
            PlaylistSongs = new HashSet<PlaylistSong>();
        }

        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public int Followers { get; set; }

        public virtual User? CreatedByNavigation { get; set; }
        public virtual ICollection<PlaylistSong> PlaylistSongs { get; set; }
    }
}
