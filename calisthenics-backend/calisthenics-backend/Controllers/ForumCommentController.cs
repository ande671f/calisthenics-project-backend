using calisthenics_backend.Database;
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
    [Route("api/ForumComment")]
    public class ForumCommentController : ControllerBase
    {
        private IRepository<ForumComment> _forumCommentRepository;
        private readonly Context _context;

        public ForumCommentController(IRepository<ForumComment> forumCommentRepository, Context context)
        {
            _forumCommentRepository = forumCommentRepository;
            _context = context;
        }


        [HttpPost]
        public async Task<ActionResult<ForumComment>> CreateForumComment(ForumComment forumComment)
        {
            await _forumCommentRepository.Create(forumComment);

            return CreatedAtAction(nameof(GetForumComment), new { id = forumComment.ForumCommentId }, forumComment);

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ForumComment>>> GetForumComments()
        {
            IEnumerable<ForumComment> forumCommentsResponse = await _forumCommentRepository.GetAll();
            return forumCommentsResponse.ToList();
        }

        [HttpGet("GetForumCommentsByPostId/{postId}")]
        public async Task<ActionResult<IEnumerable<ForumComment>>> GetForumCommentsByPostId(string postId)
        {
            List<ForumComment> forumCommentsResponse = await _context.ForumComments.Where(e => e.ForumPostId == postId)
                .Include(f => f.ForumMember)
                .ToListAsync();
            return forumCommentsResponse;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ForumComment>> GetForumComment(string id)
        {
            ForumComment forumCommentReponse = await _forumCommentRepository.GetById(id);
            return forumCommentReponse;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateForumComment(string id, ForumComment forumComment)
        {
            if (id != forumComment.ForumCommentId)
            {
                return BadRequest();
            }

            try
            {
                await _forumCommentRepository.Update(id, forumComment);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ForumCommentExists(id))
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
        public async Task<ActionResult> DeleteForumComment(string id)
        {
            await _forumCommentRepository.Delete(id);

            return NoContent();
        }

        private bool ForumCommentExists(string id) =>
            _forumCommentRepository.Exists(id);
    }
}
