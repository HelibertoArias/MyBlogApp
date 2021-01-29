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

        public async Task<IEnumerable<PostItemModel>> GetPostsDrafOrRejectedsByAutorId(ulong autorId)
        {
            var posts = await _postRepository.GetPostsDrafOrRejectedsByAutorId(autorId)
                                             .ConfigureAwait(false);


            var response = _mapper.Map<ICollection<Post>, ICollection<PostItemModel>>(posts);

            return response;
        }

        public async Task<IEnumerable<PostItemModel>> GetPostsToApprove()
        {
            var posts = await _postRepository.GetPostsToApprove()
                                             .ConfigureAwait(false);


            var response = _mapper.Map<ICollection<Post>, ICollection<PostItemModel>>(posts);

            return response;
        }
        

        /// <summary>
        /// find the post id.
        /// </summary>
        /// <param name="postId">the post id.</param>
        /// <returns>a Task<PostModel> containing the post id.</returns>
        public async Task<PostEditAddModel> Find(ulong postId)
        {
            var post = await _postRepository.Find(postId).ConfigureAwait(false);
            if (post == null)
            {
                return null;
            }

            var response = _mapper.Map<Post, PostEditAddModel>(post);
            return response;

        }

        /// <summary>
        /// get the post status.
        /// </summary>
        /// <returns>a Task<IEnumerable<PostStatusModel>> containing the get post status.</returns>
        public async Task<IEnumerable<PostStatusModel>> GetPostStatus()
        {
            var postsStatus = await _postRepository.GetPostStatus().ConfigureAwait(false);
            if (postsStatus == null)
            {
                return null;
            }

            var response = _mapper.Map<IEnumerable<PostStatus>, IEnumerable<PostStatusModel>>(postsStatus);
            return response;

        }

        /// <summary>
        /// update the post.
        /// </summary>
        /// <param name="model">the post edit add model.</param>
        /// <returns>the task.</returns>
        public  async Task UpdatePost(PostEditAddModel model)
        {
            var entity = _mapper.Map<PostEditAddModel, Post>(model);
            await _postRepository.UpdatePost(entity);
            
        }

        /// <summary>
        /// update the post status.
        /// </summary>
        /// <param name="model">the post edit add model.</param>
        /// <param name="postStatusModel">the post status model.</param>
        /// <returns>the task.</returns>
        public async Task UpdatePostStatus(PostEditAddModel model, PostStatusModel postStatusModel)
        {
            var entity = _mapper.Map<PostEditAddModel, Post>(model);
            entity.PostStatusId = postStatusModel.PostStatusId;

            await _postRepository.UpdatePost(entity);

        }

        /// <summary>
        /// create the post.
        /// </summary>
        /// <param name="model">the post edit add model.</param>
        /// <returns>the task.</returns>
        public async Task CreatePost(PostEditAddModel model)
        {
            var entity = _mapper.Map<PostEditAddModel, Post>(model);
            await _postRepository.CreatePost(entity).ConfigureAwait(false);

        }

    }
}
