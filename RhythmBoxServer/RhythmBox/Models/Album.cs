using System;
using System.Collections.Generic;

namespace RhythmBox.Models;

public partial class Album
{
    public int AlbumsId { get; set; }

    public int? ArtistsId { get; set; }

    public string? Title { get; set; }

    public TimeSpan? Duration { get; set; }

    public DateTime? ReleaseDate { get; set; }

    public string? AlbumImage { get; set; }

    public virtual ICollection<AlbumsLib> AlbumsLibs { get; set; } = new List<AlbumsLib>();

    public virtual Artist? Artists { get; set; }

    public virtual ICollection<Track> Tracks { get; set; } = new List<Track>();
}
