using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace new_design.DTO
{
    public class Tracks
    {
        public int TrackID { get; set; }
        public string Title { get; set; }
        public string FullName { get; set; }
        public byte[] TrackImage { get; set; }
    }
}
