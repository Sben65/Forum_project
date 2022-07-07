using forum_api.Models;

namespace forum_api.Services.Interfaces
{
    public interface ITopicService
    {
        void Create(Topic topic);

        void Delete(int id);

        Topic FindById(int id);

        List<Topic> FindAll();

        void Update(Topic topic);
    }
}
