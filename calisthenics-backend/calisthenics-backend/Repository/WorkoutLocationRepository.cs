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
	public class WorkoutLocationRepository : IRepository<WorkoutLocation>
	{

		private readonly Context _context;

		public WorkoutLocationRepository(Context context)
		{
			_context = context;
		}
		public async Task Create(WorkoutLocation workoutLocation)
		{
			_context.WorkoutLocations.Add(workoutLocation);
			await _context.SaveChangesAsync();
		}

		public Task Delete(string id)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<WorkoutLocation>> GetAll()
		{
			var response = await _context.WorkoutLocations
				.ToListAsync();
			return response;
		}

		public async Task<WorkoutLocation> GetById(string id)
		{
			var response = await _context.WorkoutLocations
				.FirstAsync(x => x.WorkoutLocationId == id);
			return response;
		}

		public Task Update(string id, WorkoutLocation _object)
		{
			throw new NotImplementedException();
		}
	}
}
