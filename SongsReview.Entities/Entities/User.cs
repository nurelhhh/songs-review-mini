using System;
using System.Collections.Generic;

namespace SongsReview.Entities.Entities;

public partial class User
{
    public string Username { get; set; } = null!;

    public string PhotoUrl { get; set; } = null!;

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
