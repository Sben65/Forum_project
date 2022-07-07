﻿using forum_api.Models;

namespace forum_api.Services.Interfaces
{
    public interface ICommentService
    {
        void Create(int idTopic, Comment comment);
        void Delete(int id);
        Comment FindById(int id);
        List<Comment> FindAll();
        void Update(Comment comment);

        void DeleteAllCommentByTopicId(int topicId);
    }
}