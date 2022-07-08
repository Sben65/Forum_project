using forum_api.Models;
using forum_api.Repositories.Interfaces;
using forum_api.Services.Interfaces;

namespace forum_api.Services
{
    public class CommentService : ICommentService
    {
        /// <summary>
        /// the Comment repository.
        /// </summary>
        private readonly ICommentRepository _repository;
        private readonly IWordFilterService _wordFilterService;

        public CommentService(ICommentRepository repository, IWordFilterService wordFilterService)
        {
            _repository = repository;
            _wordFilterService = wordFilterService;
        }

        /// <summary>
        /// Find all the 
        /// </summary>
        /// <returns> A list of comment.</returns>
        public List<Comment> FindAll()
        {
            return this._repository.FindAll();
        }

        /// <summary>
        /// find a comment with the id.
        /// </summary>
        /// <param name="id">comment id.</param>
        /// <returns>comment.</returns>
        public Comment FindById(int id)
        {
            Comment comment = this._repository.FindById(id);
            if (comment == null)
            {
                throw new ArgumentException($"Le commentaire avec l'id {id} est introuvable.");
            }
            return comment;
        }

        /// <summary>
        /// create a comment and give it the topic id.
        /// </summary>
        /// <param name="idTopic">the topic id.</param>
        /// <param name="comment">the comment object.</param>
        public void Create(int topicId, Comment comment)
        {
            comment.DateCreation = DateTime.Now;
            comment.DerniereModification = DateTime.Now;
            comment.TopicIdTopic = topicId;
            comment.Contenue = this._wordFilterService.FilterWord(comment.Contenue);
            this._repository.Create(comment);
        }

        /// <summary>
        /// Update a comment.
        /// </summary>
        /// <param name="comment">the comment.</param>
        public void Update(Comment comment)
        {
            comment.DerniereModification = DateTime.Now;
            comment.Contenue = this._wordFilterService.FilterWord(comment.Contenue);
            this._repository.Update(comment);
        }

        /// <summary>
        /// Delete a comment.
        /// </summary>
        /// <param name="id">the comment id.</param>
        public void Delete(int id)
        {
            this._repository.Delete(id);
        }

        public void DeleteAllCommentByTopicId(int topicId)
        {
            var commentsList = FindAll().Where(x => x.TopicIdTopic == topicId);

            if (commentsList.Any())
            {
                foreach (var item in commentsList)
                {
                    Delete(item.Id);
                }
            }
        }
    }
}
