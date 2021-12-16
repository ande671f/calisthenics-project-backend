using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace calisthenics_backend.Models
{
	public enum Gender
	{
		Woman,
		Man
	}
	
	public class PersonalProgress
	{
		[Key]
		public string PersonalProgressId { get; set; }
		public double Height { get; set; }
		public int Age { get; set; }
		public Gender Gender { get; set; }

		//navigation properties
		public string CommunityMemberId { get; set; }

		public List<WeightListing> WeightListings { get; set; }

	}
}
