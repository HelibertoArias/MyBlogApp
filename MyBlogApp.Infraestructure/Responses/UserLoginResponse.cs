namespace MyBlogApp.Infraestructure.Responses
{
    /// <summary>
    /// user login response.
    /// </summary>
    public class UserLoginResponse
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public ulong Id { get; set; }

        /// <summary>
        /// Gets or sets the user name.
        /// </summary>
        /// 
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the role name.
        /// </summary>
        public string RoleName { get; set; }

        /// <summary>
        /// Gets or sets the role id.
        /// </summary>
        public ulong RoleId { get; set; }
    }
}
