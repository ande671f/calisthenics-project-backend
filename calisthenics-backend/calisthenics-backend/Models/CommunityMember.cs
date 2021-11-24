using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace calisthenics_backend.Models
{
    public class CommunityMember
    {
        public int CommunityMemberId { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }


        // Navigation properties
        public int ForumMemberId { get; set; }
    }
}
