using forum_api.Models;

namespace forum_api.Repositories.Interfaces
{
    public interface ITopicRepository
    {
        void Create(Topic topic);

        void Delete(int id);

        List<Topic> FindAll();

        Topic FindById(int id);

        void Update(Topic topic);
    }
}
