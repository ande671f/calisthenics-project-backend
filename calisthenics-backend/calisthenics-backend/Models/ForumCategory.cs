using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace calisthenics_backend.Models
{
    public class ForumCategory
    {
        public string ForumCategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public List<ForumPost> ForumPosts { get; set; }


    }
}
