using AutoMapper;
using MyBlogApp.Core.Entities;
using MyBlogApp.Core.Respositories;
using MyBlogApp.Infraestructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBlogApp.Infraestructure.Services
{
    /// <summary>
    /// post service.
    /// </summary>
    public class PostService
    {
        /// <summary>
        /// the mapper.
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// the post respository.
        /// </summary>
        private readonly IPostRespository _postRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="PostService"/> class.
        /// </summary>
        /// <param name="mapper">the mapper.</param>
        /// <param name="postRepository">the post respository.</param>
        public PostService(IMapper mapper,
                            IPostRespository postRepository)
        {
            _mapper = mapper;
            _postRepository = postRepository;
        }

        /// <summary>
        /// get the posts draf and rejecteds by user.
        /// </summary>
        /// <param name="autorId">the autor id.</param>
        /// <returns>a IEnumerable<PostList> containing the get posts draf and rejecteds by user.</returns>

        public async Task<IEnumerable<PostList>> GetPostsDrafOrRejectedsByAutorId(ulong autorId)
        {
            var posts = await _postRepository.GetPostsDrafOrRejectedsByAutorId(autorId)
                                             .ConfigureAwait(false);


            var response = _mapper.Map<ICollection<Post>, ICollection<PostList>>(posts);

            return response;
        }
    }
}
