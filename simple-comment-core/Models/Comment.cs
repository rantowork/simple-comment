using Swashbuckle.AspNetCore.Annotations;

namespace simple_comment_core.Models
{
    /// <summary>
    /// Model that represents a comment left by a user on the website.
    /// </summary>
    public class Comment
    {
        [SwaggerSchema(ReadOnly = true)]
        public int Id { get; set; }
        public string? User { get; set; }
        public string? CommentText { get; set; }
        public string? Email { get; set; }
    }
}
