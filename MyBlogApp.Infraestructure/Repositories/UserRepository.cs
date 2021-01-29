using Microsoft.EntityFrameworkCore;
using MyBlogApp.Core.Entities;
using MyBlogApp.Core.Respositories;
using System;
using System.Linq;

namespace MyBlogApp.Infraestructure.Repositories
{
    /// <summary>
    /// user repository.
    /// </summary>
    public class UserRepository : IUserRepository
    {

        /// <summary>
        /// the data context.
        /// </summary>
        private readonly DataContext dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="dbContext">the data context.</param>
        public UserRepository(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// login the username.
        /// </summary>
        /// <param name="username">the username.</param>
        /// <param name="password">the password.</param>
        /// <returns>the user.</returns>
        public User Login(string username, string password)
        {
            var results = dbContext.Users
                            .Where(x => x.Username.ToLower().Equals(username.ToLower())
                                        && x.Password.Equals(password))
                            .Include(x=>x.Role);

            return (results.Any()) ? results.First() : null;

        }
    }
}
