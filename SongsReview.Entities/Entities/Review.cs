using System;
using System.Collections.Generic;

namespace SongsReview.Entities.Entities;

public partial class Review
{
    public int ReviewId { get; set; }

    public string Review1 { get; set; } = null!;

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset UpdatedAt { get; set; }

    public string? Username { get; set; }

    public int? SongId { get; set; }

    public virtual Song? Song { get; set; }

    public virtual User? UsernameNavigation { get; set; }
}
