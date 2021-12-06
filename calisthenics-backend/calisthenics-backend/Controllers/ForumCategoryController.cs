using calisthenics_backend.Interface;
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
    [Route("api/ForumCategory")]
    public class ForumCategoryController : ControllerBase
    {
        private IRepository<ForumCategory> _forumCategoryRepository;

        public ForumCategoryController(IRepository<ForumCategory> forumCategoryRepositry)
        {
            _forumCategoryRepository = forumCategoryRepositry;
        }

        [HttpPost]
        public async Task<ActionResult> CreateForumCategory(ForumCategory forumCategory)
        {
            await _forumCategoryRepository.Create(forumCategory);
            return CreatedAtAction(nameof(GetForumCategory), new { id = forumCategory.ForumCategoryId }, forumCategory);
        }

        [HttpGet("id")]
        public async Task<ActionResult<ForumCategory>> GetForumCategory (string id)
        {
            ForumCategory reponse;

            reponse = await _forumCategoryRepository.GetById(id);

            return reponse;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ForumCategory>>> GetForumCategories()
        {
            IEnumerable<ForumCategory> response;
            try
            {
                response = await _forumCategoryRepository.GetAll();
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return response.ToList();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateForumCategory(string id, ForumCategory forumCategory)
        {
            if (id != forumCategory.ForumCategoryId)
            {
                return BadRequest();
            }

            try
            {
                await _forumCategoryRepository.Update(id, forumCategory);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ForumPostExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteForumCategory(string id)
        {
            await _forumCategoryRepository.Delete(id);

            return NoContent();
        }


        private bool ForumPostExists(string id) =>
            _forumCategoryRepository.Exists(id);





    }
}
