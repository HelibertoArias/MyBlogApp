using MyBlogApp.Core.Entities;

namespace MyBlogApp.Core.Respositories
{
    public interface IUserRepository
    {
        User Login(string username, string password);
    }
}
