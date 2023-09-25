using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using simple_comment_api.Models;

namespace simple_comment_api.Controllers
{
    [Route("api/v1/")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        /// <summary>
        /// API endpoint for getting all comments from the database.
        /// </summary>
        /// <returns>A collection of comments.</returns>
        [HttpGet]
        [Route("comments")]
        public List<Comment> GetAllComments()
        {
            var comments = new List<Comment>
            {
                new Comment { Id = 1, CommentText = "This is a brand new comment!", Email = "tim@milyli.com", User = "Tim Randall" },
                new Comment { Id = 2, CommentText = "This is the second comment.", Email = "quinn@milyli.com", User = "Quinn Palmer" }
            };

            return comments;
        }

        /// <summary>
        /// Gets a specific comment by comment Id.
        /// </summary>
        /// <param name="id">The index of the comment being requested.</param>
        /// <returns>200 Response with the requested comment in the body of the response.</returns>
        [HttpGet]
        [Route("comments/{id}")]
        public IActionResult GetComment(int id)
        {
            var comments = new List<Comment>
            {
                new Comment { Id = 1, CommentText = "This is a brand new comment!", Email = "tim@milyli.com", User = "Tim Randall" },
                new Comment { Id = 2, CommentText = "This is the second comment.", Email = "quinn@milyli.com", User = "Quinn Palmer" }
            };

            var comment = comments.FirstOrDefault(comment => comment.Id == id);

            if (comment != null)
            {
                return Ok(comment);
            }
            else { return BadRequest(); }
        }
    }
}
