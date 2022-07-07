using System;
using System.Collections.Generic;

namespace forum_api.Models
{
    public partial class Topic
    {
        public Topic()
        {
            Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }
        public DateTime? DateCreation { get; set; }
        public string? Titre { get; set; }
        public string? Createur { get; set; }
        public DateTime? DateModification { get; set; }

        public virtual ICollection<Comment>? Comments { get; set; }
    }
}
