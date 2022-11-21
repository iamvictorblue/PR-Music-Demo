using System;
using System.Collections.Generic;

namespace DataLayer.Entities
{
    public partial class SongPlayer
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid UsersId { get; set; }
        public Guid SongId { get; set; }
        public Guid ArtistId { get; set; }
        public TimeSpan SongLength { get; set; }
        public TimeSpan StartTime { get; set; }

        public virtual Artist Artist { get; set; } 
        public virtual User? CreatedByNavigation { get; set; }
        public virtual Song Song { get; set; } 
        public virtual User Users { get; set; } = null!;
    }
}
