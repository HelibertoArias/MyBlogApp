using System.Collections.Generic;

namespace MyBlogApp.Core.Entities
{
    public class Post
    {
        public ulong PostId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public ulong  AutorId { get; set; }
        
        public User Autor { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public PostStatus PostStatus { get; set; }

        public ulong PostStatusId { get; set; }

        
    }
}
