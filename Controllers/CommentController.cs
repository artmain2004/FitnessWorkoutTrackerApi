using FitnessWorkoutTrackerApi.Request.Comments;
using FitnessWorkoutTrackerApi.Service.Comments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessWorkoutTrackerApi.Controllers
{
    [Route("api/comments")]
    [ApiController]
    [Authorize]
    public class CommentController(ICommentService commentService) : ControllerBase
    {
        [HttpPost("")]

        public async Task<ActionResult> Create([FromBody] CreateCommentRequest createCommentRequest)
        {
            var result = await commentService.CreateCommentAsync(createCommentRequest);

            return Ok(result);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            var result = await commentService.DeleteCommentAsync(id);

            return Ok(result);
        }
    }
}
