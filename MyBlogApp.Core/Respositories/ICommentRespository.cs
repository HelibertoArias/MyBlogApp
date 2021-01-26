using MyBlogApp.Core.Entities;
using System.Threading.Tasks;

namespace MyBlogApp.Core.Respositories
{
    public interface ICommentRespository
    {
        Task CreateComment(Comment comment);
    }
}
