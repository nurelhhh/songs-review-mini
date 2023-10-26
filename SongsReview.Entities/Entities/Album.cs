using System;
using System.Collections.Generic;

namespace SongsReview.Entities.Entities;

public partial class Album
{
    public int AlbumId { get; set; }

    public string Name { get; set; } = null!;

    public int? ArtistId { get; set; }

    public int ReleaseYear { get; set; }

    public string CoverArtUrl { get; set; } = null!;

    public virtual Artist? Artist { get; set; }

    public virtual ICollection<Song> Songs { get; set; } = new List<Song>();
}
