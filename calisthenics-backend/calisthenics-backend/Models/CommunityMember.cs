using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace calisthenics_backend.Models
{
    public class CommunityMember
    {
        public string CommunityMemberId { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
		public bool IsInstructor { get; set; }


		// Navigation properties
		public string ForumMemberId { get; set; }

		public PersonalProgress PersonalProgress { get; set; }
		public ICollection<Workout> Workouts { get; set; }
        public List<CommunityMemberWorkout> CommunityMemberWorkout { get; set; }
    }
}
