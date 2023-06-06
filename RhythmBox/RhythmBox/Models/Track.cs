using System;
using System.Collections.Generic;

namespace RhythmBox.Models;

public partial class Track
{
    public int TracksId { get; set; }

    public int? AlbumsId { get; set; }

    public int? ArtistsId { get; set; }

    public string? Title { get; set; }

    public TimeSpan? Duration { get; set; }

    public string? Genre { get; set; }

    public DateTime? ReleaseDate { get; set; }

    public string? SongUrl { get; set; }

    public string? LyricsUrl { get; set; }

    public string? TrackImage { get; set; }

    public virtual Album? Albums { get; set; }

    public virtual Artist? Artists { get; set; }

    public virtual ICollection<History> Histories { get; set; } = new List<History>();
}
