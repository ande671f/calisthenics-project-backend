using calisthenics_backend.Interface;
using calisthenics_backend.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace calisthenics_backend.Controllers
{
	[ApiController]
	[Route("api/WorkoutType")]
	public class WorkoutTypeController : ControllerBase
	{
		private IRepository<WorkoutType> _workoutTypeRepository;

		public WorkoutTypeController(IRepository<WorkoutType> workoutTypeRepository)
		{
			_workoutTypeRepository = workoutTypeRepository;
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<WorkoutType>> GetWorkoutLocation(string id)
		{
			WorkoutType response;
			try
			{
				response = await _workoutTypeRepository.GetById(id);
			}
			catch (Exception)
			{
				return BadRequest();
			}

			return response;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<WorkoutType>>> GetWorkoutLocations()
		{
			IEnumerable<WorkoutType> response;
			try
			{
				response = await _workoutTypeRepository.GetAll();
			}
			catch (Exception)
			{
				return BadRequest();
			}

			return response.ToList();
		}


		[HttpPost]
		public async Task<ActionResult> CreateWorkoutLocation(WorkoutType workoutType)
		{
			await _workoutTypeRepository.Create(workoutType);
			return CreatedAtAction(nameof(GetWorkoutLocation), new { id = workoutType.WorkoutTypeId }, workoutType);
		}
	}
}
