using System;
namespace RhythmBox.Models
{
	public class AddTrack
	{
		public int albumId { get; set; }
		public int artistId { get; set; }
		public string title { get; set; } = null!;
		public TimeSpan duration { get; set; }
		public string genre { get; set; } = null!;
		public DateTime releaseDate { get; set; }
		public int plays { get; set; }
		public byte[] song { get; set; } = null!;
		public byte[] lyrics { get; set; } = null!;
    }
}

