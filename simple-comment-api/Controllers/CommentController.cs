using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using simple_comment_api.Data.Contexts;
using simple_comment_api.Models;
using System.Net;

namespace simple_comment_api.Controllers
{
    [Route("api/v1/")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly CommentContext _commentContext;

        public CommentController(CommentContext context) 
        { 
            _commentContext = context;
        }

        /// <summary>
        /// API endpoint for getting all comments from the database.
        /// </summary>
        /// <returns>A collection of comments.</returns>
        [HttpGet]
        [Route("comments")]
        public async Task<List<Comment>> GetAllComments()
        {
            return await _commentContext.Comments.ToListAsync();
        }

        /// <summary>
        /// Gets a specific comment by comment Id.
        /// </summary>
        /// <param name="id">The index of the comment being requested.</param>
        /// <returns>200 Response with the requested comment in the body of the response.</returns>
        [HttpGet]
        [Route("comments/{id}")]
        public async Task<IActionResult> GetComment(int id)
        {
            var comment = await _commentContext.Comments.FindAsync(id);

            if (comment != null)
            {
                return Ok(comment);
            }
            else { return BadRequest(); }
        }

        /// <summary>
        /// Creates a new comment.
        /// </summary>
        /// <param name="comment">Represents a name, email, and comment text.</param>
        /// <returns>URI of the created comment and the created comment object.</returns>
        [HttpPost]
        [Route("comments/create")]
        public async Task<IActionResult> CreateComment(Comment comment)
        {
            if (comment == null)
            {
                return BadRequest();
            }

            if (string.IsNullOrEmpty(comment.CommentText))
            {
                return BadRequest("Comment required!");
            }

            await _commentContext.Comments.AddAsync(comment);
            await _commentContext.SaveChangesAsync();

            return Created($"/comments/{comment.Id}", comment);
        }

        [HttpDelete]
        [Route("comments/delete/{id}")]
        public async Task<IActionResult> DeleteCommentById(int id)
        {
            var comment = await _commentContext.Comments.FindAsync(id);

            if (comment == null)
            {
                return BadRequest("Comment does not exist!");
            }

            _commentContext.Comments.Remove(comment);
            await _commentContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
