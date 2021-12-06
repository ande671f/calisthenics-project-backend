using calisthenics_backend.Database;
using calisthenics_backend.Interface;
using calisthenics_backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace calisthenics_backend.Repository
{
	public class ForumMemberRepository : IRepository<ForumMember>
	{
		// dependency injection, scoped
		private readonly Context _context;

		public ForumMemberRepository(Context context)
		{
			_context = context;
		}

		public async Task Create(ForumMember forumMember)
		{
			_context.ForumMembers.Add(forumMember);
			await _context.SaveChangesAsync();
		}

		public async Task Delete(string id)
		{
			var forumMember = await _context.ForumMembers.FindAsync(id);

			//if (forumMember == null)
			//{
			//	return NotFound();
			//}

			_context.ForumMembers.Remove(forumMember);
			await _context.SaveChangesAsync();

			//return NoContent();
		}

		public async Task<IEnumerable<ForumMember>> GetAll()
		{
			var response = await _context.ForumMembers
				.Include(c => c.CommunityMember)
				.ToListAsync();
			return response;
		}

		public async Task<ForumMember> GetById(string id)
		{
			var response = await _context.ForumMembers
				.Include(c => c.CommunityMember)
				.FirstAsync(x => x.ForumMemberId == id);
			return response;
		}

		public Task Update(string id, ForumMember _object)
		{
			throw new NotImplementedException();
		}

		private bool ForumMemberExists(string id)
		{
			return _context.ForumMembers.Any(e => e.ForumMemberId == id);
		}

		public bool Exists(string id) =>
			_context.ForumMembers.Any(e => e.ForumMemberId == id);
	}
}
