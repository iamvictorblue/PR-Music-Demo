using System;
using System.Collections.Generic;

namespace DataLayer.Entities
{
    public partial class Upload
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid UsersId { get; set; }
        public Guid SongId { get; set; }


        public virtual User? CreatedByNavigation { get; set; }
        public virtual Song Song { get; set; } = null!;
        public virtual User Users { get; set; } = null!;
    }
}
