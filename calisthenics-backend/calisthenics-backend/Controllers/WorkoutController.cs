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
	[Route("api/Workout")]
	public class WorkoutController : ControllerBase
	{
		private IRepository<Workout> _workoutRepository;

		public WorkoutController(IRepository<Workout> workoutRepository)
		{
			_workoutRepository = workoutRepository;
		}


		[HttpGet("{id}")]
		public async Task<ActionResult<Workout>> GetWorkout(string id)
		{
			Workout response;
			try
			{
				response = await _workoutRepository.GetById(id);
			}
			catch (Exception)
			{
				return BadRequest();
			}

			return response;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Workout>>> GetWorkouts()
		{
			IEnumerable<Workout> response;
			try
			{
				response = await _workoutRepository.GetAll();
			}
			catch (Exception)
			{
				return BadRequest();
			}

			return response.ToList();
		}

		[HttpPost]
		public async Task<ActionResult> CreateWorkout(Workout workout)
		{
			await _workoutRepository.Create(workout);
			return CreatedAtAction(nameof(GetWorkout), new { id = workout.WorkoutId }, workout);
		}

		[HttpPut]
		public async Task<ActionResult> UpdateWorkout(string id, Workout workout)
		{
			await _workoutRepository.Update(id, workout);
			return NoContent();
		}
	}
}
