﻿using forum_api.Models;
using forum_api.Repositories.Interfaces;
using forum_api.Services.Interfaces;

namespace forum_api.Services
{
    public class TopicService : ITopicService
    {
        /// <summary>
        /// the topic repository.
        /// </summary>
        private readonly ITopicRepository _repository;

        /// <summary>
        /// the comment service.
        /// </summary>
        private readonly ICommentService _commentService;

        public TopicService(ITopicRepository repository, ICommentService commentService)
        {
            _repository = repository;
            _commentService = commentService;
        }

        /// <summary>
        /// find all the topic.
        /// </summary>
        /// <returns>a list of topic.</returns>
        public List<Topic> FindAll()
        {
            return this._repository.FindAll();
        }

        /// <summary>
        /// find a topic by his id.
        /// </summary>
        /// <param name="id">topic id.</param>
        /// <returns>topic.</returns>
        public Topic FindById(int id)
        {
            return this._repository.FindById(id);
        }

        /// <summary>
        /// create new topic.
        /// </summary>
        /// <param name="topic">the topic.</param>
        public void Create(Topic topic)
        {
            topic.DateCreation = DateTime.Now;
            topic.DateModification = DateTime.Now;
            this._repository.Create(topic);
        }

        /// <summary>
        /// update a topic.
        /// </summary>
        /// <param name="topic">the updated topic.</param>
        public void Update(Topic topic)
        {
            topic.DateModification = DateTime.Now;
            this._repository.Update(topic);
        }

        /// <summary>
        /// delete a topic with all the comment on the topic.
        /// </summary>
        /// <param name="id">topic id.</param>
        public void Delete(int id)
        {
            this._repository.Delete(id);
            this._commentService.DeleteAllCommentByTopicId(id);
        }
    }
}
