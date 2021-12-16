using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace calisthenics_backend.Models
{
	public class WeightListing
	{
		public string WeightListingId { get; set; }
		public double Weight { get; set; }
		public DateTime Date { get; set; }

		//navigation properties
		public string PersonalProgressId { get; set; }
	}
}
