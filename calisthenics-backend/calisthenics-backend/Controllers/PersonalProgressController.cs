using calisthenics_backend.Database;
using calisthenics_backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace calisthenics_backend.Controllers
{
	[ApiController]
	[Route("api/PersonalProgress")]
	public class PersonalProgressController : ControllerBase
	{
		private readonly Context _context;

		public PersonalProgressController(Context context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<PersonalProgress>>> GetPersonalProgresses()
		{
			return await _context.PersonalProgresses
				.ToListAsync();
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<PersonalProgress>> GetPersonalProgress(string id)
		{
			var personalProgess = await _context.PersonalProgresses.FindAsync(id);

			if (personalProgess == null)
			{
				return NotFound();
			}

			return personalProgess;
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdatePersonalProgress(string id, PersonalProgress personalProgressDTO)
		{
			if (id != personalProgressDTO.PersonalProgressId)
			{
				return BadRequest();
			}

			var personalProgess = await _context.PersonalProgresses.FindAsync(id);

			if (personalProgess == null)
			{
				return NotFound();
			}

			personalProgess.Height = personalProgressDTO.Height;
			personalProgess.Gender = personalProgressDTO.Gender;
			personalProgess.Age = personalProgressDTO.Age;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException) when (!PersonalProgressExists(id))
			{
				return NotFound();
			}

			return NoContent();
		}

		[HttpPost]
		public async Task<ActionResult<PersonalProgress>> CreatePersonalProgress(PersonalProgress personalProgessDTO)
		{
			var personalProgess = new PersonalProgress
			{
				PersonalProgressId = personalProgessDTO.PersonalProgressId,
				Height = personalProgessDTO.Height,
				Gender = personalProgessDTO.Gender,
				Age = personalProgessDTO.Age,
				CommunityMemberId = personalProgessDTO.CommunityMemberId,
			};

			_context.PersonalProgresses.Add(personalProgess);
			await _context.SaveChangesAsync();

			return CreatedAtAction(
				nameof(GetPersonalProgress),
				new { id = personalProgess.PersonalProgressId },
				personalProgess);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeletePersonalProgress(string id)
		{
			var personalProgess = await _context.PersonalProgresses.FindAsync(id);

			if (personalProgess == null)
			{
				return NotFound();
			}

			_context.PersonalProgresses.Remove(personalProgess);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool PersonalProgressExists(string id) =>
			_context.PersonalProgresses.Any(e => e.PersonalProgressId == id);

	}
}
