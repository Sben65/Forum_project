using forum_api.Models;
using forum_api.Repositories.Interfaces;

namespace forum_api.Repositories
{
    public class TopicRepository : ITopicRepository
    {
        private readonly forum_api_dbContext _context;

        public TopicRepository(forum_api_dbContext context)
        {
            _context = context;
        }

        public List<Topic> FindAll()
        {
            return this._context.Topics.ToList();
        }

        public Topic FindById(int id)
        {
            try
            {
                return this._context.Topics.SingleOrDefault(c => c.Id == id);
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception("",ex);
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception("", ex);
            }
        }

        public void Create(Topic topic)
        {
            _ = this._context.Topics.Add(topic);
            _ = this._context.SaveChanges();
        }

        public void Update(Topic topic)
        {
            _ = this._context.Topics.Update(topic);
            _ = this._context.SaveChanges();
        }

        public void Delete(int id)
        {
            var topic = _context.Topics.SingleOrDefault(c => c.Id == id);
            _ = this._context.Topics.Remove(topic);
            _ = this._context.SaveChanges();
        }
    }
}
