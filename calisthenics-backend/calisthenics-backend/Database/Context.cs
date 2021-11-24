using calisthenics_backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace calisthenics_backend.Database
{
	public class Context : DbContext
	{
        public DbSet<ForumMember> ForumMembers { get; set; }
		public DbSet<CommunityMember> CommunityMembers { get; set; }

        public Context(DbContextOptions<Context> options)
			: base(options)
		{
			Database.EnsureCreated();
		}
	}
}
