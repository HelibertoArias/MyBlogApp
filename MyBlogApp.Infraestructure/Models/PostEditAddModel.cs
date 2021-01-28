using System.Collections.Generic;

namespace MyBlogApp.Infraestructure.Models
{
    public class PostEditAddModel
    {
        public ulong PostId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public ulong AutorId { get; set; }

        public ulong PostStatusId { get; set; }

        public List<PostStatusModel> PostsStatusOptions { get; set; }
    }
}
