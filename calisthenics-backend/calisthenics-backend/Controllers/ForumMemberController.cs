using calisthenics_backend.Interface;
using calisthenics_backend.Models;
using calisthenics_backend.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace calisthenics_backend.Controllers
{

	[ApiController]
	[Route("api/ForumMember")]
	public class ForumMemberController : ControllerBase
	{
		private IRepository<ForumMember> _forumMemberRepository;

		public ForumMemberController(IRepository<ForumMember> forumMemberRepository)
		{
			_forumMemberRepository = forumMemberRepository;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<ForumMember>>> GetForumMembers()
		{
			IEnumerable<ForumMember> response;
			try
			{
				response = await _forumMemberRepository.GetAll();
			}
			catch (Exception)
			{
				return BadRequest();
			}

			return response.ToList();
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<ForumMember>> GetForumMember(int id)
		{
			ForumMember response;
			try
			{
				response = await _forumMemberRepository.GetById(id);
			}
			catch (Exception)
			{
				return BadRequest();
			}

			return response;
		}

		[HttpPost]
		public async Task<ActionResult> CreateForumMemeber(ForumMember forumMember)
		{
			await _forumMemberRepository.Create(forumMember);
			return CreatedAtAction(nameof(GetForumMember), new { id = forumMember.ForumMemberId }, forumMember);
		}
	}
}
