using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlogApp.Infraestructure.Models;
using MyBlogApp.Infraestructure.Services;
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
            IEnumerable<PostList> postList;

            postList = await _postService.GetPostsDrafOrRejectedsByAutorId(autorId: userId)
                            .ConfigureAwait(false);



            return View(postList);
        }

        // GET: PostController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PostController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PostController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: PostController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PostController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: PostController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PostController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
