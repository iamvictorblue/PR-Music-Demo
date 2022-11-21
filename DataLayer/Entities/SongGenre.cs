using System;
using System.Collections.Generic;

namespace DataLayer.Entities
{
    public partial class SongGenre
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid GenreId { get; set; }
        public Guid SongId { get; set; }

        public virtual User? CreatedByNavigation { get; set; }
        public virtual Genre Genre { get; set; } = null!;
        public virtual Song Song { get; set; } = null!;
    }
}
