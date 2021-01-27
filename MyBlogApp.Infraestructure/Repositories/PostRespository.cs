﻿using Microsoft.EntityFrameworkCore;
using MyBlogApp.Core.Entities;
using MyBlogApp.Core.Respositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlogApp.Infraestructure.Repositories
{
    /// <summary>
    /// post respository.
    /// </summary>
    public class PostRespository : IPostRespository
    {

        /// <summary>
        /// the data context.
        /// </summary>
        private readonly DataContext dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="PostRespository"/> class.
        /// </summary>
        /// <param name="dbContext">the data context.</param>
        public PostRespository(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// create the post.
        /// </summary>
        /// <param name="post">the post.</param>
        /// <returns>the task.</returns>
        public async Task CreatePost(Post post)
        {
            await dbContext.Posts
                .AddAsync(post)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// delete the post.
        /// </summary>
        /// <param name="post">the post.</param>
        public void DeletePost(Post post)
        {
            dbContext.Posts
                .Remove(post);
        }

        /// <summary>
        /// find the post id.
        /// </summary>
        /// <param name="postId">the post id.</param>
        /// <returns>a Task<Post> containing the post id.</returns>
        public async Task<Post> Find(ulong postId)
        {
            return await dbContext.Posts
                            .FindAsync(postId)
                            .ConfigureAwait(false);
        }

        /// <summary>
        /// get the post by status.
        /// </summary>
        /// <param name="postStatus">the post status.</param>
        /// <param name="userId">the user id.</param>
        /// <returns>a Task<ICollection<Post>> containing the get post by status.</returns>
        public async Task<ICollection<Post>> GetPostByStatus(MyBlogApp.Core.Enums.PostStatus postStatus, ulong userId)
        {
            return await dbContext.Posts
                            .Where(x => x.PostStatusId == (ulong)postStatus && x.AutorId == userId)
                            .ToListAsync()
                            .ConfigureAwait(false);
        }

        /// <summary>
        /// get the posts draf or rejecteds by autor id.
        /// </summary>
        /// <param name="userId">the user id.</param>
        /// <returns>a Task<ICollection<Post>> containing the get posts draf or rejecteds by autor id.</returns>
        public async Task<ICollection<Post>> GetPostsDrafOrRejectedsByAutorId(ulong userId)
        {
            return await dbContext.Posts
                            .Include(x=>x.Autor)
                            .Include(x=>x.PostStatus)
                            .Where(x => (x.PostStatusId == (ulong)Core.Enums.PostStatus.Approved 
                                                || x.PostStatusId == (ulong)Core.Enums.PostStatus.Draf
                                          ) && x.AutorId == userId)
                            .ToListAsync()
                            .ConfigureAwait(false);
        }

        /// <summary>
        /// update the post.
        /// </summary>
        /// <param name="post">the post.</param>
        public void UpdatePost(Post post)
        {
            dbContext.Posts
                .Update(post);
        }


    }
}
