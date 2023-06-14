using System;

namespace RhythmBox.Models
{
	public class UpdateTrack
	{
		public int trackId { get; set; }
		public string title { get; set; } = null!;
		public string genre { get; set; } = null!;
		public DateTime releaseDate { get; set; }
    }
}

