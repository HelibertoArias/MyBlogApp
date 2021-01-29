using System.Collections.Generic;

namespace MyBlogApp.Infraestructure.Models
{
    /// <summary>
    /// post list.
    /// </summary>
    public class PostListModel
    {
        public IEnumerable<PostItemModel> Items { get; set; }

        public ulong AutorId { get; set; }


        public ulong RoleId { get; set; }
        public bool CanDeletePost { get; set; }
    }
}
