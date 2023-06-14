using System;
using System.Collections.Generic;

namespace RhythmBox.Models;

public partial class Artist
{
    public int ArtistsId { get; set; }

    public string? FullName { get; set; }

    public string? BioUrl { get; set; }

    public string? ArtistsImage { get; set; }

    public virtual ICollection<Album> Albums { get; set; } = new List<Album>();

    public virtual ICollection<ArtistsLib> ArtistsLibs { get; set; } = new List<ArtistsLib>();

    public virtual ICollection<Track> Tracks { get; set; } = new List<Track>();
}
