using calisthenics_backend.Database;
using calisthenics_backend.Interface;
using calisthenics_backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace calisthenics_backend.Repository
{
    public class ForumCommentRepository : IRepository<ForumComment>
    {
        private readonly Context _context;

        public ForumCommentRepository(Context context)
        {
            _context = context;
        }

        public async Task Create(ForumComment forumComment)
        {
            await _context.ForumComments
                .AddAsync(forumComment);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ForumComment>> GetAll()
        {
            List<ForumComment> forumComments = await _context.ForumComments
                .ToListAsync();
            return forumComments;
        }

        public async Task<ForumComment> GetById(string id)
        {
            ForumComment forumComment = await _context.ForumComments
                .Include(f => f.ForumMember)
                .FirstAsync(x => x.ForumPostId == id);
            return forumComment;
            
        }

        public async Task Update(string id, ForumComment forumComment)
        {
            _context.Entry(forumComment).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public async Task Delete(string id)
        {
            ForumComment forumComment = await _context.ForumComments.FindAsync(id);
            _context.ForumComments.Remove(forumComment);
            await _context.SaveChangesAsync();
        }

        public bool Exists(string id) =>
            _context.ForumComments.Any(e => e.ForumCommentId == id);
    }
}
