using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace calisthenics_backend.Models
{
    public class ForumMember
    {
        public string ForumMemberId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }


        // Navigation properties
        public CommunityMember CommunityMember { get; set; }
    }
}
