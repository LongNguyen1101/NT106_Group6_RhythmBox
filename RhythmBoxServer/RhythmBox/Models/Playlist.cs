using System;
using System.Collections.Generic;

namespace RhythmBox.Models;

public partial class Playlist
{
    public int PlaylistId { get; set; }

    public int? UsersId { get; set; }

    public string? Title { get; set; }

    public TimeSpan? Duration { get; set; }

    public string? PlaylistCover { get; set; }

    public virtual ICollection<PlaylistTrack> PlaylistTracks { get; set; } = new List<PlaylistTrack>();

    public virtual User? Users { get; set; }
}
