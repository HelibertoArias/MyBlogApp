using Microsoft.AspNetCore.Mvc;
using MyBlogApp.Infraestructure.Requests;
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
        public IActionResult Login(UserLoginRequest request)
        {
            if (string.IsNullOrEmpty(request.Username))
            {
                ViewBag.Message = "Username is required";
            }

            if (string.IsNullOrEmpty(request.Password))
            {
                ViewBag.Message = "Password is required";
            }

            return View(request);
        }
    }
}
