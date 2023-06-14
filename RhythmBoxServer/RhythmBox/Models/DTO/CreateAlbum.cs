using System;

namespace RhythmBox.Models
{
	public class CreateAlbum
	{
		public int artistId { get; set; }
		public string title { get; set; } = null!;
		public DateTime releaseDate { get; set; }
		public byte[] image { get; set; } = null!;
	}
}

