using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace calisthenics_backend.Models
{
	public class CommunityMemberWorkout
	{
		public DateTime PublicationDate { get; set; }
		public string CommunityMemberId { get; set; }
		public string WorkoutId { get; set; }


		public CommunityMember CommunityMember { get; set; }
		public Workout Workout { get; set; }

	}
}
