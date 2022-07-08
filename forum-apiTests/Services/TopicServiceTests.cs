using Microsoft.VisualStudio.TestTools.UnitTesting;
using forum_api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using forum_api.Repositories.Interfaces;
using forum_api.Services.Interfaces;
using forum_api.Models;

namespace forum_api.Services.Tests
{
    [TestClass()]
    public class TopicServiceTests
    {
        private MockRepository mockRepository;

        private Mock<ITopicRepository> mockTopicRepository;
        private Mock<ICommentService> mockCommentService;

        private List<Topic> topicsList = new List<Topic>();

        private Mock<IWordFilterService> mockWordFilterService;

        [TestInitialize]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockTopicRepository = this.mockRepository.Create<ITopicRepository>();
            this.mockCommentService = this.mockRepository.Create<ICommentService>();
            this.mockWordFilterService = this.mockRepository.Create<IWordFilterService>();

            this.topicsList = new List<Topic>()
            {
                new Topic()
                {
                    Id = 0,
                    DateCreation = DateTime.Now,
                    DateModification = DateTime.Now,
                    Titre = "topic test 01",
                    Createur = "test C#",
                    Comments = new List<Comment>()
                    {
                        new Comment()
                        {
                            Id = 0,
                            DateCreation = DateTime.Now,
                            Createur = "test C#",
                            DerniereModification = DateTime.Now,
                            TopicIdTopic = 0,
                            Contenue = ""
                        }
                    }
                }
            };
        }

        private TopicService CreateService()
        {
            return new TopicService(this.mockTopicRepository.Object, this.mockCommentService.Object, this.mockWordFilterService.Object);
        }

        [TestMethod()]
        public void FindAllWithNoArgumentReturnAlist()
        {
            // Given
            var service = this.CreateService();

            this.mockTopicRepository
                .Setup(x => x.FindAll())
                .Returns(this.topicsList);

            // Act
            var result = service.FindAll();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(this.topicsList, result);

            this.mockRepository.VerifyAll();
        }

        [TestMethod()]
        [DataRow(0)]
        public void FindByIdWithGoodArgumentReturnATopic(int id)
        {
            // Given
            var service = this.CreateService();
            var expectedValue = this.topicsList.ElementAt(id);

            this.mockTopicRepository
                .Setup(x => x.FindById(It.Is<int>(x => x == id)))
                .Returns(expectedValue);

            // Act
            var result = service.FindById(id);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedValue, result);

            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        [DataRow(7)]
        public void FindByIdWithInvalidArgumentShouldThrowAnexception(int id)
        {
            // Given
            var service = this.CreateService();

            this.mockTopicRepository
                .Setup(x => x.FindById(It.Is<int>(x => x == id)))
                .Throws (new InvalidOperationException(""));

            // Assert
            Assert.ThrowsException<InvalidOperationException>(() => service.FindById(id));

            this.mockRepository.VerifyAll();
        }

        [TestMethod()]
        public void CreateWithGoodArgumentShouldNotFail()
        {
            // given
            var service = this.CreateService();
            var newTopic = this.topicsList.ElementAt(0);

            this.mockTopicRepository.Setup(x => x.Create(It.IsAny<Topic>()));

            this.mockWordFilterService.Setup(x => x.FilterWord(It.IsAny<string>())).Returns("");

            // act
            service.Create(newTopic);

            // Assert
            this.mockTopicRepository.Verify(x => x.Create(It.IsAny<Topic>()), Times.Once());
        }

        [TestMethod()]
        public void UpdateWithGoodArgumentShouldNotFail()
        {
            // given
            var service = this.CreateService();
            var newTopic = this.topicsList.ElementAt(0);

            this.mockTopicRepository.Setup(x => x.Update(It.IsAny<Topic>()));

            this.mockWordFilterService.Setup(x => x.FilterWord(It.IsAny<string>())).Returns("");

            // act
            service.Update(newTopic);

            // Assert
            this.mockTopicRepository.Verify(x => x.Update(It.IsAny<Topic>()), Times.Once());
        }

        [TestMethod()]
        public void DeleteWithNoArgumentShouldNotFail()
        {
            // given
            var service = this.CreateService();

            this.mockTopicRepository.Setup(x => x.Delete(It.IsAny<int>()));
            this.mockCommentService.Setup(x => x.DeleteAllCommentByTopicId(It.IsAny<int>()));

            // act
            service.Delete(0);

            // Assert
            this.mockTopicRepository.Verify(x => x.Delete(It.IsAny<int>()), Times.Once());
            this.mockCommentService.Verify(x => x.DeleteAllCommentByTopicId(It.IsAny<int>()), Times.Once());
        }
    }
}