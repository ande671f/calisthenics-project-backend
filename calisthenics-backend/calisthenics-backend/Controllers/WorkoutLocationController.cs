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
	[Route("api/WorkoutLocation")]
	public class WorkoutLocationController : ControllerBase
	{
		private IRepository<WorkoutLocation> _workoutLocationRepository;

		public WorkoutLocationController(IRepository<WorkoutLocation> workoutLocationRepository)
		{
			_workoutLocationRepository = workoutLocationRepository;
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<WorkoutLocation>> GetWorkoutLocation(string id)
		{
			WorkoutLocation response;
			try
			{
				response = await _workoutLocationRepository.GetById(id);
			}
			catch (Exception)
			{
				return BadRequest();
			}

			return response;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<WorkoutLocation>>> GetWorkoutLocations()
		{
			IEnumerable<WorkoutLocation> response;
			try
			{
				response = await _workoutLocationRepository.GetAll();
			}
			catch (Exception)
			{
				return BadRequest();
			}

			return response.ToList();
		}


		[HttpPost]
		public async Task<ActionResult> CreateWorkoutLocation(WorkoutLocation workoutLocation)
		{
			await _workoutLocationRepository.Create(workoutLocation);
			return CreatedAtAction(nameof(GetWorkoutLocation), new { id = workoutLocation.WorkoutLocationId }, workoutLocation);
		}
	}
}
