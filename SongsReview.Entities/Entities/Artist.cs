using System;
using System.Collections.Generic;

namespace SongsReview.Entities.Entities;

public partial class Artist
{
    public int ArtistId { get; set; }

    public string Name { get; set; } = null!;

    public string PhotoUrl { get; set; } = null!;

    public virtual ICollection<Album> Albums { get; set; } = new List<Album>();
}
