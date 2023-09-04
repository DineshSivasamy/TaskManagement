using Microsoft.Extensions.Logging;
using Model;
using Moq;
using NUnit.Framework;
using Repository.Interface;
using Services.Interface;
using Services.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Tests
{
    [TestFixture]
    public class UserServicesTests
    {
        private Mock<IUserRepository> _userRepository;
        private Mock<IRepositoryBase<User>> _repositoryBase;
        private Mock<IUserFavoriteJiraTaskService> _userFavTaskservice;

        private IUserService _userService;

        [SetUp]
        public void Setup()
        {
            _userRepository = new Mock<IUserRepository>();
            _repositoryBase = new Mock<IRepositoryBase<User>>();
            _userService = new UserService(_userRepository.Object);
        }

        [Test]
        public void Delete_User_Valid()
        {
            _repositoryBase.Setup(x => x.Get(It.IsAny<Expression<Func<User, bool>>>())).Returns((new List<User>() { new User { Id = Guid.NewGuid(), UserName = "test", Email = "test@gmail.com", Role = UserRole.User } }).AsQueryable());
            _repositoryBase.Setup(x => x.Delete(It.IsAny<User>())).Returns(true);

            var result = _userService.Delete(Guid.NewGuid());

            Assert.AreEqual(true, result);
        }

        [TestCase("9ac1f3fa-c58f-418d-8e7b-c0c2a66f896f")]
        [TestCase("18529165-bd9d-4cf0-b3dd-23bae63e4f85")]
        [TestCase("9e56978b-5bd4-4047-9ca9-83383e2a078a")]
        public void Delete_User_ReturnsFalse(Guid userId)
        {
            _repositoryBase.Setup(x => x.Get(It.IsAny<Expression<Func<User, bool>>>())).Returns((new List<User>() { new User { Id = Guid.NewGuid(), UserName = "test", Email = "test@gmail.com", Role = UserRole.User } }).AsQueryable());
            _repositoryBase.Setup(x => x.Delete(It.IsAny<User>())).Returns(false);

            var result = _userService.Delete(userId);

            Assert.AreEqual(false, result);
        }
    }
}