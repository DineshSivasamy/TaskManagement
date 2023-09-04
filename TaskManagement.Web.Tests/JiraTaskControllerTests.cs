using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using Repository.Interface;
using Services.Interface;
using TaskManagement.Web.Controllers;

namespace TaskManagement.Web.Tests
{
    [TestFixture]
    public class JiraTaskControllerTests
    {
        private Mock<IJiraTaskRepository> _jiraTaskRepository;
        private Mock<IJiraTaskService> _jiraTaskService;
        private Mock<ILogger<JiraTaskController>> _logger;
        private JiraTaskController _jiraTaskController;

        [SetUp]
        public void Setup()
        {
            _jiraTaskRepository = new Mock<IJiraTaskRepository>();
            _jiraTaskService = new Mock<IJiraTaskService>();
            _logger = new Mock<ILogger<JiraTaskController>>();
            _jiraTaskController = new JiraTaskController(_logger.Object, _jiraTaskService.Object);
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}
