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
	[Route("api/CommunityMember")]
	public class CommunityMemberController : ControllerBase
	{
		private IRepository<CommunityMember> _communityMemberRepository;

		public CommunityMemberController(IRepository<CommunityMember> communityMemberRepository)
		{
			_communityMemberRepository = communityMemberRepository;
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<CommunityMember>> GetCommunityMember(string id)
		{
			CommunityMember response;
			try
			{
				response = await _communityMemberRepository.GetById(id);
			}
			catch (Exception)
			{
				return BadRequest();
			}

			return response;
		}

		[HttpPost]
		public async Task<ActionResult> CreateCommunityMember(CommunityMember communityMember)
		{
			await _communityMemberRepository.Create(communityMember);
			return CreatedAtAction(nameof(GetCommunityMember), new { id = communityMember.CommunityMemberId }, communityMember);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteCommunityMember(string id)
		{
			await _communityMemberRepository.Delete(id);
			return NoContent();
		}

		[HttpPut]
		public async Task<ActionResult> UpdateCommunityMember(string id, CommunityMember communityMember)
		{
			await _communityMemberRepository.Update(id, communityMember);
			return NoContent();
		}
	}
}
