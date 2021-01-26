using MyBlogApp.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBlogApp.Core.Respositories
{
    public interface IPostRespository
    {

        Task<ICollection<Post>> GetPostByStatus(PostStatus postStatus);

        Task CreatePost(Post post);

        void UpdatePost(Post post);

        void DeletePost(Post post);

        Task<Post> Find(ulong postId);
    }
}
