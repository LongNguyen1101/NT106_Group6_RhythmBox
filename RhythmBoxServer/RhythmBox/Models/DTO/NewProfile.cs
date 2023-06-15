using Microsoft.Build.Framework;

namespace RhythmBox.Models.DTO
{
    public class NewProfile
    {
        public string userName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public DateTime birthday { get; set; }
    }
}
