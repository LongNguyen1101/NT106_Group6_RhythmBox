using System;
using System.Collections.Generic;

namespace RhythmBox.Models;

public partial class Playlist
{
    public int PlaylistId { get; set; }

    public int? UsersId { get; set; }

    public string? Title { get; set; }

    public TimeSpan? Duration { get; set; }

    public int? TracksId { get; set; }

    public virtual Track? Tracks { get; set; }

    public virtual User? Users { get; set; }
}
