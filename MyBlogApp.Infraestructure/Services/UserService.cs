using AutoMapper;
using MyBlogApp.Core.Respositories;
using MyBlogApp.Infraestructure.Models;
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
        /// <param name="mapper">the mapper.</param>
        /// <param name="userRepostory">the user repository.</param>
        public UserService(IMapper mapper, 
                            IUserRepository userRepostory)
        {
            _userRepository = userRepostory;
        }

        /// <summary>
        /// login the login request.
        /// </summary>
        /// <param name="loginRequest">the user login.</param>
        /// <returns>the user login response.</returns>
        public UserLoginResponse Login(UserLogin loginRequest)
        {
            if (loginRequest == null)
            {
                throw new ArgumentNullException();
            }

            var user = _userRepository.Login(loginRequest.Username, loginRequest.Password);

            if (user == null)
            {
                return null;
            }

            return new UserLoginResponse { RoleName = user.Role.Name, Id = user.UserId, Username = user.Username };
        }
    }
}
