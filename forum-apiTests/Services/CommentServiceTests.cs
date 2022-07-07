﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using forum_api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using forum_api.Repositories;
using Moq;
using forum_api.Models;
using forum_api.Services.Interfaces;
using forum_api.Repositories.Interfaces;

namespace forum_api.Services.Tests
{
    [TestClass()]
    public class CommentServiceTests
    {
        private CommentService _service;
        private Mock<CommentRepository> _repository;
        private List<Comment> _comments;

        private MockRepository mockRepository;
        private Mock<ICommentService> mockCommentService;
        private Mock<ICommentRepository> mockCommentRepository;

        [TestInitialize]
        public void Initialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
            this.mockCommentService = this.mockRepository.Create<ICommentService>();
            this.mockCommentRepository = this.mockRepository.Create<ICommentRepository>();

            _repository = new Mock<CommentRepository>(null);
            _service = new CommentService(_repository.Object);
            _comments = new List<Comment>();
            _comments.Add(new Comment() { Id = 1, Createur = "Stevie", Contenue = ":)" });
            _comments.Add(new Comment() { Id = 2, Createur = "Ben", Contenue = ";)" });
            _comments.Add(new Comment() { Id = 3, Createur = "Thomas", Contenue = ":(" });
        }

        private CommentService CreateService()
        {
            return new CommentService(this.mockCommentRepository.Object);
        }

        [TestMethod]
        public void FindAllWithNoArgumentReturnAList()
        {
            //GIVEN
            var service = this.CreateService();
            this.mockCommentRepository.Setup(x => x.FindAll()).Returns(this._comments);

            //ACT
            var result = service.FindAll();

            //ASSERT
            Assert.IsNotNull(result);
            Assert.AreEqual(this._comments, result);
            this.mockRepository.VerifyAll();
        }

        [TestMethod()]
        public void CreateWithGoodArgumentShouldNotFail()
        {
            //GIVEN
            var service = this.CreateService();
            var newComment = this._comments.ElementAt(0);

            this.mockCommentRepository.Setup(x => x.Create(It.IsAny<Comment>()));

            //ACT
            service.Create(newComment);

            //ASSERT
            this.mockCommentRepository.Verify(x => x.Create(It.IsAny<Comment>()), Times.Once());

        }

        [TestMethod()]
        [DataRow(1)]
        [DataRow(3)]
        public void FindById_IdOk(int id)
        {
            //GIVEN
            _repository.Setup((repo) => repo.FindById(id)).Returns(_comments.Find(v => v.Id == id));
            Comment expectedComment = _comments.Find(v => v.Id == id);
            //WHEN
            Comment comment = _service.FindById(id);
            //THEN
            Assert.AreEqual(expectedComment, comment);
        }

        [TestMethod()]
        [DataRow(5)]
        public void FindById_idPasOk(int id)
        {
            //GIVEN
            _repository.Setup((repo) => repo.FindById(id)).Returns(_comments.Find(v => v.Id == id));
            //WHEN / THEN
            Assert.ThrowsException<ArgumentException>(() =>
            {
                _service.FindById(id);
            });
        }
    }
}