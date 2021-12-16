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
	public class WorkoutRepository : IRepository<Workout>
	{

		// dependency injection, scoped
		private readonly Context _context;

		public WorkoutRepository(Context context)
		{
			_context = context;
		}

		public async Task Create(Workout workout)
		{
			_context.Workouts.Add(workout);
			await _context.SaveChangesAsync();
		}

		public Task Delete(string id)
		{
			throw new NotImplementedException();
		}

		public bool Exists(string id)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<Workout>> GetAll()
		{
			var response = await _context.Workouts.Where(x => x.Date > DateTime.Now).OrderBy(d => d.Date)
				.Include(t => t.WorkoutType)
				.Include(l => l.WorkoutLocation)
				.Include(c => c.CommunityMembers)
				.ToListAsync();
			return response;
		}

		public async Task<Workout> GetById(string id)
		{
			var response = await _context.Workouts
				.Include(l => l.WorkoutLocation)
				.Include(t => t.WorkoutType)
				.FirstAsync(x => x.WorkoutId == id);
			return response;
		}

		public async Task Update(string id, Workout dto)
		{
			var workout = await _context.Workouts
				.Include(c => c.CommunityMembers)
				.FirstOrDefaultAsync(w => w.WorkoutId == dto.WorkoutId);

			workout.CommunityMembers.Clear();

			var availableCommunityMembers = await _context.CommunityMembers.ToListAsync();
			foreach (var member in dto.CommunityMembers)
			{
				workout.CommunityMembers.Add(availableCommunityMembers.First(c => c.CommunityMemberId == member.CommunityMemberId));
			}

			await _context.SaveChangesAsync();

		}

		private bool WorkoutExists(string id)
		{
			return _context.Workouts.Any(e => e.WorkoutId == id);
		}
	}
}
