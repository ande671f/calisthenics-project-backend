using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace calisthenics_backend.Models
{
    public class ForumComment
    {
        public string ForumCommentId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public string ForumPostId { get; set; }

    }
}
