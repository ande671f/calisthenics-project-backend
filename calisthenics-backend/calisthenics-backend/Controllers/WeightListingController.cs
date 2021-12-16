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
	[Route("api/WeightListing")]
	public class WeightListingController : ControllerBase
	{
		private readonly Context _context;

		public WeightListingController(Context context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<WeightListing>>> GetWeightListings()
		{
			var response = await _context.WeightListings.OrderByDescending(d => d.Date)
				.ToListAsync();

			Console.WriteLine(response);

			return response;
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<WeightListing>> GetWeightListing(string id)
		{
			var weightListing = await _context.WeightListings.FindAsync(id);

			if (weightListing == null)
			{
				return NotFound();
			}

			return weightListing;
		}

		[HttpPost]
		public async Task<ActionResult<WeightListing>> CreateWeightListing(WeightListing weightListingDTO)
		{
			var weightListing = new WeightListing
			{
				WeightListingId = weightListingDTO.WeightListingId,
				Weight = weightListingDTO.Weight,
				Date = DateTime.UtcNow,
				PersonalProgressId = weightListingDTO.PersonalProgressId,
			};

			_context.WeightListings.Add(weightListing);
			await _context.SaveChangesAsync();

			return CreatedAtAction(
				nameof(GetWeightListing),
				new { id = weightListing.WeightListingId },
				weightListing);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteWeightListing(string id)
		{
			var weightListing = await _context.WeightListings.FindAsync(id);

			if (weightListing == null)
			{
				return NotFound();
			}

			_context.WeightListings.Remove(weightListing);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool WeightListingExists(string id) =>
			_context.WeightListings.Any(e => e.WeightListingId == id);

	}
}
