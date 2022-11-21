using System;
using System.Collections.Generic;

namespace DataLayer.Entities
{
    public partial class Song
    {
        public Song()
        {
            AlbumGenres = new HashSet<AlbumGenre>();
            Albums = new HashSet<Album>();
            PlaylistSongs = new HashSet<PlaylistSong>();
            SongGenres = new HashSet<SongGenre>();
            SongPlayers = new HashSet<SongPlayer>();
            Uploads = new HashSet<Upload>();
        }

        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public string Title { get; set; } 
        public string Album { get; set; } 
        public string Artist { get; set; }
        public string Genre { get; set; } 
        public DateTime ReleaseDate { get; set; }
        public bool IsSingle { get; set; }

        public virtual User CreatedByNavigation { get; set; } = null!;
        public virtual ICollection<AlbumGenre> AlbumGenres { get; set; }
        public virtual ICollection<Album> Albums { get; set; }
        public virtual ICollection<PlaylistSong> PlaylistSongs { get; set; }
        public virtual ICollection<SongGenre> SongGenres { get; set; }
        public virtual ICollection<SongPlayer> SongPlayers { get; set; }
        public virtual ICollection<Upload> Uploads { get; set; }
    }
}
