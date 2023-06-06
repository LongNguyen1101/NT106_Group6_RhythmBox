using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RhythmBox.Models;

namespace RhythmBox.Data;

public partial class RhythmboxdbContext : DbContext
{
    public RhythmboxdbContext()
    {
    }

    public RhythmboxdbContext(DbContextOptions<RhythmboxdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Album> Albums { get; set; }

    public virtual DbSet<AlbumsLib> AlbumsLibs { get; set; }

    public virtual DbSet<Artist> Artists { get; set; }

    public virtual DbSet<ArtistsLib> ArtistsLibs { get; set; }

    public virtual DbSet<History> Histories { get; set; }

    public virtual DbSet<Playlist> Playlists { get; set; }

    public virtual DbSet<Track> Tracks { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Album>(entity =>
        {
            entity.HasKey(e => e.AlbumsId);

            entity.ToTable("ALBUMS");

            entity.Property(e => e.AlbumsId).HasColumnName("ALBUMS_ID");
            entity.Property(e => e.AlbumImage)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ALBUM_IMAGE");
            entity.Property(e => e.ArtistsId).HasColumnName("ARTISTS_ID");
            entity.Property(e => e.Duration)
                .HasPrecision(0)
                .HasColumnName("DURATION");
            entity.Property(e => e.ReleaseDate)
                .HasColumnType("date")
                .HasColumnName("RELEASE_DATE");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasColumnName("TITLE");

            entity.HasOne(d => d.Artists).WithMany(p => p.Albums)
                .HasForeignKey(d => d.ArtistsId)
                .HasConstraintName("FK_ALBUMS_ARTISTS");
        });

        modelBuilder.Entity<AlbumsLib>(entity =>
        {
            entity.ToTable("ALBUMS_LIB");

            entity.Property(e => e.AlbumsLibId).HasColumnName("ALBUMS_LIB_ID");
            entity.Property(e => e.AlbumsId).HasColumnName("ALBUMS_ID");
            entity.Property(e => e.UsersId).HasColumnName("USERS_ID");

            entity.HasOne(d => d.Albums).WithMany(p => p.AlbumsLibs)
                .HasForeignKey(d => d.AlbumsId)
                .HasConstraintName("FK_ALBUMS_LIB_ALBUMS");

            entity.HasOne(d => d.Users).WithMany(p => p.AlbumsLibs)
                .HasForeignKey(d => d.UsersId)
                .HasConstraintName("FK_ALBUMS_LIB_USERS");
        });

        modelBuilder.Entity<Artist>(entity =>
        {
            entity.HasKey(e => e.ArtistsId);

            entity.ToTable("ARTISTS");

            entity.Property(e => e.ArtistsId).HasColumnName("ARTISTS_ID");
            entity.Property(e => e.ArtistsImage)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ARTISTS_IMAGE");
            entity.Property(e => e.BioUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("BIO_URL");
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .HasColumnName("FULL_NAME");
        });

        modelBuilder.Entity<ArtistsLib>(entity =>
        {
            entity.ToTable("ARTISTS_LIB");

            entity.Property(e => e.ArtistsLibId).HasColumnName("ARTISTS_LIB_ID");
            entity.Property(e => e.ArtistsId).HasColumnName("ARTISTS_ID");
            entity.Property(e => e.UsersId).HasColumnName("USERS_ID");

            entity.HasOne(d => d.Artists).WithMany(p => p.ArtistsLibs)
                .HasForeignKey(d => d.ArtistsId)
                .HasConstraintName("FK_ARTISTS_LIB_ARTISTS");

            entity.HasOne(d => d.Users).WithMany(p => p.ArtistsLibs)
                .HasForeignKey(d => d.UsersId)
                .HasConstraintName("FK_ARTISTS_LIB_USERS");
        });

        modelBuilder.Entity<History>(entity =>
        {
            entity.ToTable("HISTORY");

            entity.Property(e => e.HistoryId).HasColumnName("HISTORY_ID");
            entity.Property(e => e.DurationPlayed)
                .HasPrecision(0)
                .HasColumnName("DURATION_PLAYED");
            entity.Property(e => e.PlayedAt)
                .HasColumnType("datetime")
                .HasColumnName("PLAYED_AT");
            entity.Property(e => e.TracksId).HasColumnName("TRACKS_ID");
            entity.Property(e => e.UsersId).HasColumnName("USERS_ID");

            entity.HasOne(d => d.Tracks).WithMany(p => p.Histories)
                .HasForeignKey(d => d.TracksId)
                .HasConstraintName("FK_HISTORY_TRACKS");

            entity.HasOne(d => d.Users).WithMany(p => p.Histories)
                .HasForeignKey(d => d.UsersId)
                .HasConstraintName("FK_HISTORY_USERS");
        });

        modelBuilder.Entity<Playlist>(entity =>
        {
            entity.ToTable("PLAYLIST");

            entity.Property(e => e.PlaylistId).HasColumnName("PLAYLIST_ID");
            entity.Property(e => e.Duration)
                .HasPrecision(0)
                .HasColumnName("DURATION");
            entity.Property(e => e.PlaylistCover)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("PLAYLIST_COVER");
            entity.Property(e => e.Title)
                .HasMaxLength(20)
                .HasColumnName("TITLE");
            entity.Property(e => e.TracksId).HasColumnName("TRACKS_ID");
            entity.Property(e => e.UsersId).HasColumnName("USERS_ID");

            entity.HasOne(d => d.Tracks).WithMany(p => p.Playlists)
                .HasForeignKey(d => d.TracksId)
                .HasConstraintName("FK_PLAYLIST_TRACKS");

            entity.HasOne(d => d.Users).WithMany(p => p.Playlists)
                .HasForeignKey(d => d.UsersId)
                .HasConstraintName("FK_PLAYLIST_USERS");
        });

        modelBuilder.Entity<Track>(entity =>
        {
            entity.HasKey(e => e.TracksId);

            entity.ToTable("TRACKS");

            entity.Property(e => e.TracksId).HasColumnName("TRACKS_ID");
            entity.Property(e => e.AlbumsId).HasColumnName("ALBUMS_ID");
            entity.Property(e => e.ArtistsId).HasColumnName("ARTISTS_ID");
            entity.Property(e => e.Duration)
                .HasPrecision(0)
                .HasColumnName("DURATION");
            entity.Property(e => e.Genre)
                .HasMaxLength(50)
                .HasColumnName("GENRE");
            entity.Property(e => e.LyricsUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("LYRICS_URL");
            entity.Property(e => e.ReleaseDate)
                .HasColumnType("date")
                .HasColumnName("RELEASE_DATE");
            entity.Property(e => e.SongUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("SONG_URL");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasColumnName("TITLE");
            entity.Property(e => e.TrackImage)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("TRACK_IMAGE");

            entity.HasOne(d => d.Albums).WithMany(p => p.Tracks)
                .HasForeignKey(d => d.AlbumsId)
                .HasConstraintName("FK_TRACKS_ALBUMS");

            entity.HasOne(d => d.Artists).WithMany(p => p.Tracks)
                .HasForeignKey(d => d.ArtistsId)
                .HasConstraintName("FK_TRACKS_ARTISTS");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UsersId);

            entity.ToTable("USERS");

            entity.Property(e => e.UsersId).HasColumnName("USERS_ID");
            entity.Property(e => e.ArtistsId).HasColumnName("ARTISTS_ID");
            entity.Property(e => e.AvaUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("AVA_URL");
            entity.Property(e => e.Birthday)
                .HasColumnType("date")
                .HasColumnName("BIRTHDAY");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .HasColumnName("GENDER");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .HasColumnName("USER_NAME");
            entity.Property(e => e.UserPassword)
                .HasMaxLength(65)
                .IsUnicode(false)
                .HasColumnName("USER_PASSWORD");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
