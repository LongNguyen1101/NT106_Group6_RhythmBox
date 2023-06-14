using System;

namespace RhythmBox.Models
{
	public class EmailOtp
	{
		public string email { get; set; } = null!;
		public int enteredOtp { get; set; }
	}
}

