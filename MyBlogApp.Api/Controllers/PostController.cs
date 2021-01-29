using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlogApp.Infraestructure.Models;
using MyBlogApp.Infraestructure.Services;

namespace MyBlogApp.Api.Controllers
{
    /// <summary>
    /// post controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly PostService _postService;
        /// <summary>
        /// Initializes a new instance of the <see cref="PostController"/> class.
        /// </summary>
        /// <param name="postService">the post service.</param>
        public PostController(PostService postService)
        {
            _postService = postService;
        }

        /// <summary>
        /// get the pending posts.
        /// </summary>
        /// <returns>a Task<IActionResult> containing the get pending posts.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PostItemModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetPendingPosts()
        {
            var post = await _postService.GetPostsToApprove().ConfigureAwait(false);

            return Ok(post);
        }

        /// <summary>
        /// get the pending posts.
        /// </summary>
        /// <param name="postId">the post id.</param>
        /// <param name="postAction">the post action.</param>
        /// <returns>a Task<IActionResult> containing the get pending posts.</returns>
        [HttpPost("Post/{postId}/{postAction}")]
        [ProducesResponseType(typeof(IEnumerable<PostItemModel>), (int)HttpStatusCode.OK)]
       
        public async Task<IActionResult> GetPendingPosts(ulong postId, ulong postAction)
        {
            if (postId <= 0)
                return BadRequest();

            
            var post = await _postService.Find(postId).ConfigureAwait(false);
            
            if (post== null)
                return NotFound();

             
            return Ok(true);
        }
    }
}
