using MyBlogApp.Core.Respositories;
using MyBlogApp.Infraestructure.Requests;
using MyBlogApp.Infraestructure.Responses;
using System;

namespace MyBlogApp.Infraestructure.Services
{
    /// <summary>
    /// user service.
    /// </summary>
    public class UserService
    {
        /// <summary>
        /// the user repository.
        /// </summary>
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="userRepostory">the user repository.</param>
        public UserService(IUserRepository userRepostory)
        {
            _userRepository = userRepostory;
        }

        public UserLoginResponse Login(UserLoginRequest loginRequest)
        {
            if (loginRequest == null)
            {
                throw new ArgumentNullException();
            }

            var user = _userRepository.Login(loginRequest.Username, loginRequest.Password);

            if (user != null)
            {
                return new UserLoginResponse { RoleName = user.Role.Name, Id = user.UserId, Username = user.Username };
            }

            return null;
        }
    }
}
