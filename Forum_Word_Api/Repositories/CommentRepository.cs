using forum_api.Models;
using forum_api.Repositories.Interfaces;

namespace forum_api.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly forum_api_dbContext _context;

        public CommentRepository(forum_api_dbContext context)
        {
            _context = context;
        }

        public virtual List<Comment> FindAll()
        {
            return this._context.Comments.ToList();
        }

        public virtual Comment FindById(int id)
        {
            return this._context.Comments.SingleOrDefault(c => c.Id == id);
        }

        public void Create(Comment comment)
        {
            this._context.Comments.Add(comment);
            this._context.SaveChanges();
        }

        public void Update(Comment comment)
        {
            _ = this._context.Comments.Update(comment);
            this._context.SaveChanges();
        }

        public void Delete(int id)
        {
            var comment = _context.Comments.SingleOrDefault(c => c.Id == id);
            _ = this._context.Comments.Remove(comment);
            this._context.SaveChanges();
        }
    }
}
