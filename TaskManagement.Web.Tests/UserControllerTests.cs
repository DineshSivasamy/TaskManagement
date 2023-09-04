using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model;
using Moq;
using NUnit.Framework;
using Repository.Interface;
using Services.Interface;
using System;
using TaskManagement.Web.Controllers;

namespace Tests
{
    [TestFixture]
    public class UserControllerTests
    {
        private Mock<IUserRepository> _userRepository;
        private Mock<IUserService> _userService;
        private Mock<IUserFavoriteJiraTaskService> _userFavTaskservice;
        private Mock<ILogger<UserController>> _logger;
        private UserController _userController;

        [SetUp]
        public void Setup()
        {
            _userRepository = new Mock<IUserRepository>();
            _userService = new Mock<IUserService>();
            _logger = new Mock<ILogger<UserController>>();
            _userFavTaskservice = new Mock<IUserFavoriteJiraTaskService>();
            _userController = new UserController(_logger.Object, _userService.Object, _userFavTaskservice.Object);
        }

        [Test]
        public void Get_User_valid()
        {
            SetupGetUser();
            var result = _userController.Get(Guid.NewGuid());

            // assert
            Assert.IsInstanceOf<IActionResult>(result);
            var resultobj = ((OkObjectResult)result).Value;
            Assert.AreEqual("test", ((User)resultobj).UserName);
            Assert.AreEqual("test@gmail.com", ((User)resultobj).UserName);
            Assert.AreEqual(0, ((User)resultobj).UserName);

        }


        public void SetupGetUser()
        {
            _userService.Setup(x => x.Get(It.IsAny<Guid>())).Returns(new User { Id = Guid.NewGuid(), UserName = "test", Email = "test@gmail.com", Role = UserRole.User });
        }
    }
}