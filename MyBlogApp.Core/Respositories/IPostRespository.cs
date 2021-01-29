using MyBlogApp.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBlogApp.Core.Respositories
{
    public interface IPostRespository
    {

        Task<ICollection<Post>> GetPostsDrafOrRejectedsByAutorId(ulong userId);

        Task CreatePost(Post post);

        Task UpdatePost(Post post);

        void DeletePost(Post post);

        Task<Post> Find(ulong postId);

        Task<IEnumerable<PostStatus>> GetPostStatus();

        Task<ICollection<Post>> GetPostsToApprove();
    }
}
