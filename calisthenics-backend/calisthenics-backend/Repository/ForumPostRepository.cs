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
    public class ForumPostRepository : IRepository<ForumPost>
    {
        private readonly Context _context;

        public ForumPostRepository(Context context)
        {
            _context = context;
        }

        public async Task Create(ForumPost forumPost)
        {
            _context.ForumPosts.Add(forumPost);
            await _context.SaveChangesAsync();
        }


        public async Task<IEnumerable<ForumPost>> GetAll()
        {
            List<ForumPost> forumPosts = await _context.ForumPosts
                .Include(f => f.ForumComments)
                .ToListAsync();
            return forumPosts;
        }

        public async Task<ForumPost> GetById(string id)
        {
            ForumPost forumPost = await _context.ForumPosts
                .Include(f => f.ForumMember)
                .Include(f => f.ForumComments)
                .FirstAsync(x => x.ForumPostId == id);
            return forumPost;
        }

        public async Task Update(string id, ForumPost forumPost)
        {
            _context.Entry(forumPost).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public async Task Delete(string id)
        {
            ForumPost forumPost = await _context.ForumPosts.FindAsync(id);
            _context.ForumPosts.Remove(forumPost);
            await _context.SaveChangesAsync();
        }

        public bool Exists(string id) =>
            _context.ForumPosts.Any(e => e.ForumPostId == id);
    }
}
