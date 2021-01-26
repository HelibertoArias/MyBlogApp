using System.Collections.Generic;

namespace MyBlogApp.Core.Entities
{
    public class User
    {
        public ulong UserId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public ulong RoleId { get; set; }

        public Role Role { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
