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

		[HttpPost]
		public async Task<ActionResult> Post(ForumMember forumMember)
		{
			await _forumMemberRepository.Create(forumMember);

			return CreatedAtAction(nameof(GetById), new { id = forumMember.Id }, forumMember);
		}

		[HttpGet]
		public ActionResult<ForumMember> GetById(int id)
		{
			ForumMember response = _forumMemberRepository.GetById(id);

			return response;
		}
	}
}
