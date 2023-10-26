namespace SongsReview.Api
{
    public class ReviewShowModel
    {
        public int ReviewId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Review { get; set; } = string.Empty;
        public string SongTitle { get; set; } = string.Empty;
        public string AlbumCoverArtUrl { get; set; } = string.Empty;
        
    }
}
