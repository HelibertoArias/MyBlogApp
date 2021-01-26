﻿namespace MyBlogApp.Infraestructure.Requests
{/// <summary>
 /// user login request.
 /// </summary>
    public class UserLoginRequest
    {
        /// <summary>
        /// Gets or sets the user name.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public string Password { get; set; }
    }
}
