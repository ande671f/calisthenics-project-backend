using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace calisthenics_backend.Models
{
	public class Workout
	{
		public string WorkoutId { get; set; }
		public DateTime Date { get; set; }

		// Navigation Properties
		public WorkoutType WorkoutType { get; set; }
		public string WorkoutTypeId { get; set; }

		public WorkoutLocation WorkoutLocation { get; set; }
		public string WorkoutLocationId { get; set; }

		public ICollection<CommunityMember> CommunityMembers { get; set; }
		public List<CommunityMemberWorkout> CommunityMemberWorkout { get; set; }
	}
}
