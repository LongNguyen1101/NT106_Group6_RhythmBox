using System;
using System.Collections.Generic;

namespace RhythmBox.Models;

public partial class AlbumsLib
{
    public int AlbumsLibId { get; set; }

    public int? UsersId { get; set; }

    public int? AlbumsId { get; set; }

    public virtual Album? Albums { get; set; }

    public virtual User? Users { get; set; }
}
