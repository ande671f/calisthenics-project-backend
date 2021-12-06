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
    [Route("api/ForumPost")]
    public class ForumPostController : ControllerBase
    {
        private IRepository<ForumPost> _forumPostRepository;

        public ForumPostController(IRepository<ForumPost> forumPostRepository)
        {
            _forumPostRepository = forumPostRepository;
        }

        [HttpPost]
        public async Task<ActionResult<ForumPost>> CreateForumPost(ForumPost forumPost)
        {
            await _forumPostRepository.Create(forumPost);

            return CreatedAtAction(nameof(GetForumPost), new { id = forumPost.ForumCategoryId }, forumPost);

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ForumPost>>> GetForumPosts ()
        {
            IEnumerable<ForumPost> forumPostsResponse = await _forumPostRepository.GetAll();
            return forumPostsResponse.ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ForumPost>> GetForumPost(string id)
        {
            ForumPost forumPostReponse = await _forumPostRepository.GetById(id);
            return forumPostReponse;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateForumPost(string id, ForumPost forumPost)
        {
            if (id != forumPost.ForumPostId)
            {
                return BadRequest();
            }

            try
            {
                await _forumPostRepository.Update(id, forumPost);
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
        public async Task<ActionResult> DeleteForumPost(string id)
        {
            await _forumPostRepository.Delete(id);

            return NoContent();
        }


        private bool ForumPostExists(string id) =>
            _forumPostRepository.Exists(id);
    }
}
