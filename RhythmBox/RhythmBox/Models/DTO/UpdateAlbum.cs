using System;

namespace RhythmBox.Models
{
	public class UpdateAlbum
	{
		public int albumId { get; set; }
		public string title { get; set; } = null!;
		public DateTime releaseDate { get;set; }
		public byte[] image { get; set; } = null!;
	}
}

