namespace MyBlogApp.Infraestructure.Models
{
    /// <summary>
    /// post list.
    /// </summary>
    public class PostList
    {
        /// <summary>
        /// Gets or sets the post id.
        /// </summary>
        public ulong PostId { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets the autor name.
        /// </summary>
        
        public string AutorName { get; set; }

        /// <summary>
        /// Gets or sets the post status id.
        /// </summary>
        public ulong PostStatusId { get; set; }

        /// <summary>
        /// Gets or sets the post status name.
        /// </summary>
        public string PostStatusName { get; set; }
    }
}
