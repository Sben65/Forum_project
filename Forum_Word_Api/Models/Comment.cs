using System;
using System.Collections.Generic;

namespace forum_api.Models
{
    public partial class Comment
    {
        public int Id { get; set; }
        public DateTime? DerniereModification { get; set; }
        public string? Createur { get; set; }
        public string? Contenue { get; set; }
        public int TopicIdTopic { get; set; }
        public DateTime? DateCreation { get; set; }

        public virtual Topic TopicIdTopicNavigation { get; set; } = null!;

        //public Comment(int id, string createur, string contenu)
        //{
        //    Id = id;
        //    Createur = createur;
        //    Contenue = contenu;
        //}
    }
}
