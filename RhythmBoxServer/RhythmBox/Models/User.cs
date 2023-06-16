using System;
using System.Collections.Generic;

namespace RhythmBox.Models;

public partial class User
{
    public int UsersId { get; set; }

    public string? UserName { get; set; }

    public string? Email { get; set; }

    public string? UserPassword { get; set; }

    public string? AvaUrl { get; set; }

    public DateTime? Birthday { get; set; }

    public string? Gender { get; set; }

    public int? ArtistsId { get; set; }

    public virtual ICollection<AlbumsLib> AlbumsLibs { get; set; } = new List<AlbumsLib>();

    public virtual ICollection<ArtistsLib> ArtistsLibs { get; set; } = new List<ArtistsLib>();

    public virtual ICollection<History> Histories { get; set; } = new List<History>();

    public virtual ICollection<Playlist> Playlists { get; set; } = new List<Playlist>();
}
