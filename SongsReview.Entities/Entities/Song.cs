using System;
using System.Collections.Generic;

namespace SongsReview.Entities.Entities;

public partial class Song
{
    public int SongId { get; set; }

    public string Title { get; set; } = null!;

    public int? AlbumId { get; set; }

    public virtual Album? Album { get; set; }

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
