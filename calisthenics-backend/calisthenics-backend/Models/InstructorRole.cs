using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace calisthenics_backend.Models
{
	public class InstructorRole
	{
		public string InstructorRoleId { get; set; }

		public bool	isInstructorActive { get; set; }

		public string CommunityMemberId { get; set; }
	}
}
