namespace simple_comment_api.Models
{
    /// <summary>
    /// Model that represents a comment left by a user on the website.
    /// </summary>
    public class Comment
    {
        public int Id { get; set; }
        public string? User { get; set; }
        public string? CommentText { get; set; }
        public string? Email { get; set; }
    }
}
