using Microsoft.VisualStudio.TestTools.UnitTesting;
using forum_api.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using forum_api.Services.Interfaces;
using forum_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace forum_api.Controllers.Tests
{
    [TestClass()]
    public class CommentsControllerTests
    {
        private MockRepository mockRepository;

        private Mock<ICommentService> mockCommentService;

        [TestInitialize]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockCommentService = this.mockRepository.Create<ICommentService>();
        }

        private CommentsController CreateController()
        {
            return new CommentsController(this.mockCommentService.Object);
        }

        [TestMethod()]
        public void FindAllShouldReturnOkResult()
        {
            // Arrange
            var controller = CreateController();
            var listComment = new List<Comment>();

            _ = this.mockCommentService
                .Setup(x => x.FindAll())
                .Returns(listComment);

            // act
            var response = controller.FindAll();
            var okResult = response as OkObjectResult;

            //assert
            Assert.IsNotNull(response);
            Assert.AreEqual(200, okResult?.StatusCode);
        }

        [TestMethod()]
        public void FindByIdShouldReturnOkResult()
        {
            // Arrange
            var controller = CreateController();

            _ = this.mockCommentService
                .Setup(x => x.FindById(It.IsAny<int>()))
                .Returns(new Comment());

            // act
            var response = controller.FindById(0);
            var okResult = response as OkObjectResult;

            //assert
            Assert.IsNotNull(response);
            Assert.AreEqual(200, okResult?.StatusCode);
        }

        [TestMethod()]
        public void CreateShouldReturnOkResult()
        {
            // Arrange
            var controller = CreateController();

            _ = this.mockCommentService
                .Setup(x => x.Create(It.IsAny<int>(), It.IsAny<Comment>()));

            // act
            var response = controller.Create(0, new Comment());
            var okResult = response as OkObjectResult;

            //assert
            Assert.IsNotNull(response);
            mockCommentService.Verify(x => x.Create(It.IsAny<int>(), It.IsAny<Comment>()), Times.Once());
            Assert.AreEqual(200, okResult?.StatusCode);
        }
    }
}