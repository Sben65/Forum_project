using forum_api.Models;

namespace forum_api.Services.Interfaces
{
    public interface ICommentService
    {
        void Create(Comment comment);
        void Delete(int id);
        Comment FindById(int id);
        List<Comment> FindAll();
        List<Comment> FindCommentsByTopicsId(int topicId);
        void Update(Comment comment);

        void DeleteAllCommentByTopicId(int topicId);

    }
}
