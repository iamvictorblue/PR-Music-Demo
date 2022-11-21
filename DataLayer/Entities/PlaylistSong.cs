using System;
using System.Collections.Generic;

namespace DataLayer.Entities
{
    public partial class PlaylistSong
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid PlaylistId { get; set; }
        public Guid SongId { get; set; }

        public virtual User? CreatedByNavigation { get; set; }
        public virtual Playlist Playlist { get; set; } 
        public virtual Song Song { get; set; } = null!;
    }
}
