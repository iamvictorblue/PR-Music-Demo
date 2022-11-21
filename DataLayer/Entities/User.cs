using System;
using System.Collections.Generic;

namespace DataLayer.Entities
{
    public partial class User
    {
        public User()
        {
            AlbumArtists = new HashSet<AlbumArtist>();
            AlbumGenres = new HashSet<AlbumGenre>();
            Albums = new HashSet<Album>();
            Artists = new HashSet<Artist>();
            Genres = new HashSet<Genre>();
            InverseCreatedByNavigation = new HashSet<User>();
            PlaylistSongs = new HashSet<PlaylistSong>();
            Playlists = new HashSet<Playlist>();
            SongGenres = new HashSet<SongGenre>();
            SongPlayerCreatedByNavigations = new HashSet<SongPlayer>();
            SongPlayerUsers = new HashSet<SongPlayer>();
            Songs = new HashSet<Song>();
            UploadCreatedByNavigations = new HashSet<Upload>();
            UploadUsers = new HashSet<Upload>();
        }

        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid? CreatedBy { get; set; }
        public string FirstName { get; set; } 
        public string LastName { get; set; } 
        public string Email { get; set; } 
        public string Password { get; set; } 

        public virtual User? CreatedByNavigation { get; set; }
        public virtual ICollection<AlbumArtist> AlbumArtists { get; set; }
        public virtual ICollection<AlbumGenre> AlbumGenres { get; set; }
        public virtual ICollection<Album> Albums { get; set; }
        public virtual ICollection<Artist> Artists { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }
        public virtual ICollection<User> InverseCreatedByNavigation { get; set; }
        public virtual ICollection<PlaylistSong> PlaylistSongs { get; set; }
        public virtual ICollection<Playlist> Playlists { get; set; }
        public virtual ICollection<SongGenre> SongGenres { get; set; }
        public virtual ICollection<SongPlayer> SongPlayerCreatedByNavigations { get; set; }
        public virtual ICollection<SongPlayer> SongPlayerUsers { get; set; }
        public virtual ICollection<Song> Songs { get; set; }
        public virtual ICollection<Upload> UploadCreatedByNavigations { get; set; }
        public virtual ICollection<Upload> UploadUsers { get; set; }
    }
}
