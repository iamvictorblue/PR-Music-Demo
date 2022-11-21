using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataLayer.Entities
{
    public partial class PRMusicContext : DbContext
    {
        public PRMusicContext()
        {
        }

        public PRMusicContext(DbContextOptions<PRMusicContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Album> Albums { get; set; } = null!;
        public virtual DbSet<AlbumArtist> AlbumArtists { get; set; } = null!;
        public virtual DbSet<AlbumGenre> AlbumGenres { get; set; } = null!;
        public virtual DbSet<Artist> Artists { get; set; } = null!;
        public virtual DbSet<Genre> Genres { get; set; } = null!;
        public virtual DbSet<Playlist> Playlists { get; set; } = null!;
        public virtual DbSet<PlaylistSong> PlaylistSongs { get; set; } = null!;
        public virtual DbSet<Song> Songs { get; set; } = null!;
        public virtual DbSet<SongGenre> SongGenres { get; set; } = null!;
        public virtual DbSet<SongPlayer> SongPlayers { get; set; } = null!;
        public virtual DbSet<Upload> Uploads { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-MK6RFPJ\\SQLEXPRESS;Database=PRMusic;UserID=sa; Password=Conelperm1so");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>(entity =>
            {
                entity.ToTable("Album");

                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.AlbumLength).HasColumnName("Album_Length");

                entity.Property(e => e.Genre).HasMaxLength(100);

                entity.Property(e => e.IsSingle).HasColumnName("Is_Single");

                entity.Property(e => e.ReleaseDate)
                    .HasColumnType("date")
                    .HasColumnName("Release_Date");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.Albums)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("fk_Album_CreatedBy_Users_Id");

                entity.HasOne(d => d.Song)
                    .WithMany(p => p.Albums)
                    .HasForeignKey(d => d.SongId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Album_SongId_Song_Id");
            });

            modelBuilder.Entity<AlbumArtist>(entity =>
            {
                entity.ToTable("AlbumArtist");

                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getutcdate())");

                entity.HasOne(d => d.Album)
                    .WithMany(p => p.AlbumArtists)
                    .HasForeignKey(d => d.AlbumId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_AlbumArtist_AlbumsId_Album_Id");

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.AlbumArtists)
                    .HasForeignKey(d => d.ArtistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_AlbumArtist_ArtistsId_Artist_Id");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.AlbumArtists)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("fk_AlbumArtist_CreatedBy_Users_Id");
            });

            modelBuilder.Entity<AlbumGenre>(entity =>
            {
                entity.ToTable("AlbumGenre");

                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getutcdate())");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.AlbumGenres)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("fk_AlbumGenre_CreatedBy_Users_Id");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.AlbumGenres)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_AlbumGenre_GenreId_Genre_Id");

                entity.HasOne(d => d.Song)
                    .WithMany(p => p.AlbumGenres)
                    .HasForeignKey(d => d.SongId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_AlbumGenre_SongsId_Songs_Id");
            });

            modelBuilder.Entity<Artist>(entity =>
            {
                entity.ToTable("Artist");

                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.About).HasMaxLength(1000);

                entity.Property(e => e.ArtistName).HasMaxLength(50);

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getutcdate())");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.Artists)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("fk_Artist_CreatedBy_Users_Id");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("Genre");

                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.Genres)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("fk_Genre_CreatedBy_Users_Id");
            });

            modelBuilder.Entity<Playlist>(entity =>
            {
                entity.ToTable("Playlist");

                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getutcdate())");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.Playlists)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("fk_Playlist_CreatedBy_Users_Id");
            });

            modelBuilder.Entity<PlaylistSong>(entity =>
            {
                entity.ToTable("PlaylistSong");

                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getutcdate())");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.PlaylistSongs)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("fk_PlaylistSong_CreatedBy_Users_Id");

                entity.HasOne(d => d.Playlist)
                    .WithMany(p => p.PlaylistSongs)
                    .HasForeignKey(d => d.PlaylistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_PlaylistSong_PaylistId_Playlist_Id");

                entity.HasOne(d => d.Song)
                    .WithMany(p => p.PlaylistSongs)
                    .HasForeignKey(d => d.SongId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_PlaylistSong_SongsId_Song_Id");
            });

            modelBuilder.Entity<Song>(entity =>
            {
                entity.ToTable("Song");

                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Album).HasMaxLength(100);

                entity.Property(e => e.Artist).HasMaxLength(100);

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Genre).HasMaxLength(100);

                entity.Property(e => e.IsSingle).HasColumnName("Is_Single");

                entity.Property(e => e.ReleaseDate)
                    .HasColumnType("date")
                    .HasColumnName("Release_date");

                entity.Property(e => e.Title).HasMaxLength(100);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.Songs)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Songs_CreatedBy_Users_Id");
            });

            modelBuilder.Entity<SongGenre>(entity =>
            {
                entity.ToTable("SongGenre");

                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getutcdate())");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.SongGenres)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("fk_SongGenre_CreatedBy_Users_Id");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.SongGenres)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_SongGenre_GenreId_Genre_Id");

                entity.HasOne(d => d.Song)
                    .WithMany(p => p.SongGenres)
                    .HasForeignKey(d => d.SongId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_SongGenre_SongsId_Songs_Id");
            });

            modelBuilder.Entity<SongPlayer>(entity =>
            {
                entity.ToTable("SongPlayer");

                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.SongLength).HasColumnName("Song_length");

                entity.Property(e => e.StartTime).HasColumnName("Start_time");

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.SongPlayers)
                    .HasForeignKey(d => d.ArtistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_SongPlayer_ArtistsId_Artist_Id");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.SongPlayerCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("fk_SongPlayer_CreatedBy_User_Id");

                entity.HasOne(d => d.Song)
                    .WithMany(p => p.SongPlayers)
                    .HasForeignKey(d => d.SongId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_SongPlayer_SongId_Song_Id");

                entity.HasOne(d => d.Users)
                    .WithMany(p => p.SongPlayerUsers)
                    .HasForeignKey(d => d.UsersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_SongPlayer_UsersId_Users_Id");
            });

            modelBuilder.Entity<Upload>(entity =>
            {
                entity.ToTable("Upload");

                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getutcdate())");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.UploadCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("fk_Upload_CreatedBy_Users_Id");

                entity.HasOne(d => d.Song)
                    .WithMany(p => p.Uploads)
                    .HasForeignKey(d => d.SongId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Upload_SongId_Song_Id");

                entity.HasOne(d => d.Users)
                    .WithMany(p => p.UploadUsers)
                    .HasForeignKey(d => d.UsersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Upload_UsersId_Users_Id");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.InverseCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("fk_Users_CreatedBy_Users_Id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
