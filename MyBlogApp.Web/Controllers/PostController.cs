using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlogApp.Core.Enums;
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

            var roleId = (ulong)HttpContext.Session.GetInt32("RoleId");

            var canDeletePost = false;
            if(roleId == (ulong)RoleEnum.Writer)
            {
                postList = await _postService.GetPostsDrafOrRejectedsByAutorId(autorId: userId)
                            .ConfigureAwait(false);
            }
            else
            {

                postList = await _postService.GetPostsToApprove()
                           .ConfigureAwait(false);

                canDeletePost = true;
            }
            


            var postListModel = new PostListModel
            {
                AutorId = userId,
                Items = postList,
                CanDeletePost = canDeletePost

            };

            return View(postListModel);
        }



        /// <summary>
        /// create the user id.
        /// </summary>
        /// <param name="userId">the user id.</param>
        /// <returns>a Task<IActionResult> containing the user id.</returns>
       
        public async Task<IActionResult> Create(ulong userId)
        {
            var roleId = (ulong)HttpContext.Session.GetInt32("RoleId");

            var postModel = new PostEditAddModel
            {
                AutorId = userId,
                RoleId = roleId,
                PostsStatusOptions = (List<PostStatusModel>)await _postService.GetPostStatus()
            };

            return View(postModel);
        }

        // POST: PostController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PostEditAddModel model)
        {
            try
            {
                await _postService.CreatePost(model);
                var roleId = (ulong)HttpContext.Session.GetInt32("RoleId");
                return RedirectToAction(nameof(Index), new { userId = model.AutorId, roleId = model.RoleId });
            }
            catch
            {
                model.PostsStatusOptions = (List<PostStatusModel>)await _postService.GetPostStatus();
                return View(model);
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

               await _postService.UpdatePost(model);
                var roleId = (ulong)HttpContext.Session.GetInt32("RoleId");
                return RedirectToAction(nameof(Index), new { userId = model.AutorId , roleId = model.RoleId });
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
                return RedirectToAction(nameof(Index), new { userId = model.AutorId, roleId = model.RoleId });
            }
            catch
            {
                return View();
            }
        }
    }
}
