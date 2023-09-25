namespace simple_comment_api.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string? User { get; set; }
        public string? CommentText { get; set; }
        public string? Email { get; set; }
    }
}
