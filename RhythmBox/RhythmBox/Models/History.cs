using System;
using System.Collections.Generic;

namespace RhythmBox.Models;

public partial class History
{
    public int HistoryId { get; set; }

    public int? TracksId { get; set; }

    public int? UsersId { get; set; }

    public DateTime? PlayedAt { get; set; }

    public TimeSpan? DurationPlayed { get; set; }

    public virtual Track? Tracks { get; set; }

    public virtual User? Users { get; set; }
}
