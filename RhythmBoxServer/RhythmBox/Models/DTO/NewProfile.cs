using Microsoft.Build.Framework;

namespace RhythmBox.Models.DTO
{
    public class NewProfile
    {
        public string userName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public DateTime birthday { get; set; }
    }
}
