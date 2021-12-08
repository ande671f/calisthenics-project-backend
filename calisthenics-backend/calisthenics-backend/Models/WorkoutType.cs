using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace calisthenics_backend.Models
{
	public class WorkoutType
	{
		public string WorkoutTypeId { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }

		public List<Workout> Workouts { get; set; }
	}
}
