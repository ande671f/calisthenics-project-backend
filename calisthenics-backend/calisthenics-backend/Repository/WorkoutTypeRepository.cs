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
	public class WorkoutTypeRepository : IRepository<WorkoutType>
	{
		private readonly Context _context;

		public WorkoutTypeRepository(Context context)
		{
			_context = context;
		}

		public async Task Create(WorkoutType workoutType)
		{
			_context.WorkoutTypes.Add(workoutType);
			await _context.SaveChangesAsync();
		}

		public Task Delete(string id)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<WorkoutType>> GetAll()
		{
			var response = await _context.WorkoutTypes
				.ToListAsync();
			return response;
		}

		public async Task<WorkoutType> GetById(string id)
		{
			var response = await _context.WorkoutTypes
			.FirstAsync(x => x.WorkoutTypeId == id);
			return response;
		}

		public Task Update(string id, WorkoutType _object)
		{
			throw new NotImplementedException();
		}
	}
}
