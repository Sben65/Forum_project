using forum_api.Models;

namespace forum_api.Repositories.Interfaces
{
    public interface ICommentRepository
    {
        void Create(Comment category);

        void Delete(int id);

        List<Comment> FindAll();

        Comment FindById(int id);

        void Update(Comment comment);
        //List<Comment> FindCommentsByTopicsId(int topicId);
    }
}
