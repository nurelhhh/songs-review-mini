using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SongsReview.Entities.Entities;

namespace SongsReview.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly SongsReviewContext _srContext;
        private readonly ILogger<ReviewController> _logger;

        public ReviewController(SongsReviewContext srContext, ILogger<ReviewController> logger)
        {
            _srContext = srContext;
            _logger = logger;
        }

        [HttpGet(Name = "Get User Reviews")]
        public async Task<ActionResult<List<ReviewShowModel>>> Get(string username)
        {
            try
            {
                var list = await (from r in this._srContext.Reviews
                                  join u in this._srContext.Users on r.Username equals u.Username
                                  join s in this._srContext.Songs on r.SongId equals s.SongId
                                  join al in this._srContext.Albums on s.AlbumId equals al.AlbumId
                                  where u.Username == username
                                  select new ReviewShowModel
                                  {
                                      ReviewId = r.ReviewId,
                                      SongTitle = s.Title,
                                      Username = username,
                                      AlbumCoverArtUrl = al.CoverArtUrl,
                                      Review = r.Review1
                                  }).ToListAsync();

                return Ok(list);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
            
        }

        [HttpPatch("update-user-review", Name = "Update User Review")]
        public async Task<ActionResult<string>> Update([FromBody] ReviewUpdateModel model)
        {
            var check = await this._srContext.Reviews
                .AsTracking()
                .Where(Q => Q.ReviewId == model.ReviewId)
                .FirstOrDefaultAsync();

            if (check == null)
            {
                return NotFound("Cannot find the review");
            }

            check.Review1 = model.NewReview;
            check.UpdatedAt = DateTimeOffset.Now;

            try
            {
                await this._srContext.SaveChangesAsync();

                return Ok("Success");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete(Name = "Delete User Review")]
        public async Task<ActionResult<string>> Delete(int reviewId)
        {
            var check = await this._srContext.Reviews
                .AsNoTracking()
                .Where(Q => Q.ReviewId == reviewId)
                .FirstOrDefaultAsync();

            if (check == null)
            {
                return NotFound("Cannot find the review");
            }

            try
            {
                this._srContext.Reviews.Remove(check);
                await this._srContext.SaveChangesAsync();

                return Ok("Success");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}