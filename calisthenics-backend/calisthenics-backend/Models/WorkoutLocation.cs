using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace calisthenics_backend.Models
{
	public class WorkoutLocation
	{
		public string WorkoutLocationId { get; set; }
		public string City { get; set; }
		public string Address { get; set; }
		public string Zip { get; set; }
		public string Description { get; set; }

		// Navigation Properties
		public List<Workout> Workouts { get; set; }
	}
}
