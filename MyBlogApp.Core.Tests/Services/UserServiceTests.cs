using Moq;
using MyBlogApp.Core.Entities;
using MyBlogApp.Core.Respositories;
using MyBlogApp.Infraestructure.Models;
using MyBlogApp.Infraestructure.Services;
using Xunit;

namespace MyBlogApp.Core.Tests.Service
{

    public class UserServiceTests
    {
        [Fact]
        public void ShouldThrowArgumentNullException()
        {
            UserLogin loginRequest = null;

            var userRepository = new Mock<IUserRepository>();
            var userService = new UserService(userRepository.Object);

            Assert.Throws<System.ArgumentNullException>(() => userService.Login(loginRequest));
        }

        [Fact]
        public void ShouldNullWhenUserDoesNotExist()
        {
            var loginRequest = new UserLogin { Username = "JanenotExist", Password = "pass" };



            var userRepository = new Mock<IUserRepository>();
            userRepository
                .Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>()))
                .Returns((User)null);

            var userService = new UserService(userRepository.Object);

            var loginResult = userService.Login(loginRequest);


            Assert.Null(loginResult);
        }


    }
}
