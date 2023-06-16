using System;
using System.Collections.Generic;

namespace RhythmBox.Models;

public partial class ArtistsLib
{
    public int ArtistsLibId { get; set; }

    public int? UsersId { get; set; }

    public int? ArtistsId { get; set; }

    public virtual Artist? Artists { get; set; }

    public virtual User? Users { get; set; }
}
