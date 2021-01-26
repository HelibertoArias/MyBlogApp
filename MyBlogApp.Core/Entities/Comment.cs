namespace MyBlogApp.Core.Entities
{
    public class Comment
    {
        public ulong CommentId { get; set; }

        public string Content { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public ulong PostId { get; set; }

        public Post Post { get; set; }

    }
}
