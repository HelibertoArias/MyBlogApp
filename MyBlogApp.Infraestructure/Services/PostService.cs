using MyBlogApp.Core.Respositories;

namespace MyBlogApp.Infraestructure.Services
{
    /// <summary>
    /// post service.
    /// </summary>
    public class PostService
    {
        /// <summary>
        /// the post respository.
        /// </summary>
        private readonly IPostRespository _postRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="PostService"/> class.
        /// </summary>
        /// <param name="postRepository">the post respository.</param>
        public PostService(IPostRespository postRepository)
        {
            _postRepository = postRepository;
        }
    }
}
