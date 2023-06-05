using System;

namespace RhythmBox
{
	public class FileContent
	{
		public byte[]? content { get; set; }
		public string? fileName { get; set; }

		public FileContent(byte[] content, string fileName)
		{
			this.content = content;
			this.fileName = fileName;
		}

		public FileContent() { }
	}
}

