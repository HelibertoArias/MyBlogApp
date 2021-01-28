using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlogApp.Infraestructure.Models;
using MyBlogApp.Infraestructure.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBlogApp.Web.Controllers
{
    /// <summary>
    /// post controller.
    /// </summary>
    public class PostController : Controller
    {

        /// <summary>
        /// the post service.
        /// </summary>
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
        /// index the user id.
        /// </summary>
        /// <param name="userId">the user id.</param>
        /// <returns>the action result.</returns>
        public async Task<ActionResult> Index(ulong userId)
        {
            IEnumerable<PostItemModel> postList;

            postList = await _postService.GetPostsDrafOrRejectedsByAutorId(autorId: userId)
                            .ConfigureAwait(false);


            var postListModel = new PostListModel
            {
                AutorId = userId,
                Items = postList
            };

            return View(postListModel);
        }

        // GET: PostController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        /// <summary>
        /// create the user id.
        /// </summary>
        /// <param name="userId">the user id.</param>
        /// <returns>a Task<IActionResult> containing the user id.</returns>
        public async Task<IActionResult> Create(ulong userId)
        {
            var postModel = new PostEditAddModel
            {
                AutorId = userId,
                PostsStatusOptions = (List<PostStatusModel>)await _postService.GetPostStatus()
            };

            return View(postModel);
        }

        // POST: PostController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PostEditAddModel model)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        /// <summary>
        /// edit the id.
        /// </summary>
        /// <param name="id">the id.</param>
        /// <returns>the action result.</returns>
        public async Task<IActionResult> Edit(ulong id)
        {
            var postModel = await _postService.Find(id).ConfigureAwait(false);
            postModel.PostsStatusOptions = (List<PostStatusModel>)await _postService.GetPostStatus();
            return View(postModel);
        }

        // POST: PostController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ulong id, PostEditAddModel model)
        {
            try
            {

                _postService.UpdatePost(model);

                return RedirectToAction(nameof(Index), new { userId = model.AutorId });
            }
            catch(Exception ex)
            {
                model.PostsStatusOptions = (List<PostStatusModel>)await _postService.GetPostStatus();
                return View(model);
            }
        }

 

        // POST: PostController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, PostEditAddModel model)
        {
            try
            {
                return RedirectToAction(nameof(Index), new { userId = model.AutorId });
            }
            catch
            {
                return View();
            }
        }
    }
}
