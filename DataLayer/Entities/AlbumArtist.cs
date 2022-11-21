using System;
using System.Collections.Generic;

namespace DataLayer.Entities
{
    public partial class AlbumArtist
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid ArtistId { get; set; }
        public Guid AlbumId { get; set; }

        public virtual Album Album { get; set; } 
        public virtual Artist Artist { get; set; } 
        public virtual User? CreatedByNavigation { get; set; }
    }
}
