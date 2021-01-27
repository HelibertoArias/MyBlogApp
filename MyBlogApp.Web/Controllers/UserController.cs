using Microsoft.AspNetCore.Mvc;
using MyBlogApp.Infraestructure.Models;
using MyBlogApp.Infraestructure.Services;

namespace MyBlogApp.Web.Controllers
{
    /// <summary>
    /// user controller.
    /// </summary>
    public class UserController : Controller
    {

        /// <summary>
        /// the user service.
        /// </summary>
        private readonly UserService _userService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="userService">the user service.</param>
        public UserController(UserService userService)
        {
            _userService = userService;
        }



        /// <summary>
        /// login the .
        /// </summary>
        /// <returns>the action result.</returns>
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// login the request.
        /// </summary>
        /// <param name="request">the user login request.</param>
        /// <returns>the action result.</returns>
        [HttpPost]
        public IActionResult Login(UserLogin request)
        {
            if (string.IsNullOrEmpty(request.Username))
            {
                ViewBag.Message = "Username is required";
                return View(request);
            }

            if (string.IsNullOrEmpty(request.Password))
            {
                ViewBag.Message = "Password is required";
                return View(request);
            }

            var userLogin = _userService.Login(request);

            //if(userLogin == null)
            //{
            //    ViewBag.Message = "Sorry, we don't recognize this user. Try again.";
            //    return View(request);
            //}


            return RedirectToAction("Index", "Post", new { userId = 1 });
        }
    }
}
