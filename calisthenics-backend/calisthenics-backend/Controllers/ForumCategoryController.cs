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
    [Route("api/ForumCategory")]
    public class ForumCategoryController : ControllerBase
    {
        private IRepository<ForumCategory> _forumCategoryRepository;

        public ForumCategoryController(IRepository<ForumCategory> forumCategoryRepositry)
        {
            _forumCategoryRepository = forumCategoryRepositry;
        }

        [HttpGet("id")]
        public async Task<ActionResult<ForumCategory>> GetForumCategory (string id)
        {
            ForumCategory reponse;

            reponse = await _forumCategoryRepository.GetById(id);

            return reponse;
        }

        [HttpPost]
        public async Task<ActionResult> CreateForumCategory(ForumCategory forumCategory)
        {
            await _forumCategoryRepository.Create(forumCategory);
            return CreatedAtAction(nameof(GetForumCategory), new { id = forumCategory.ForumCategoryId }, forumCategory);
        }

    }
}
