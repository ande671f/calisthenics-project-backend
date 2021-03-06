using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace calisthenics_backend.Models
{
    public class ForumPost
    {
        public string ForumPostId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        // navigation properties
        public List<ForumComment> ForumComments { get; set; }
        public string ForumCategoryId { get; set; }
        public ForumCategory ForumCategory { get; set; }
        public string ForumMemberId { get; set; }
        public ForumMember ForumMember { get; set; }
    }
}
