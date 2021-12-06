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
    public class ForumCategoryRepository : IRepository<ForumCategory>
    {
        private readonly Context _context;

        public ForumCategoryRepository(Context context)
        {
            _context = context;
        }

        public async Task Create(ForumCategory forumCategory)
        {
            _context.ForumCategories.Add(forumCategory);
            await _context.SaveChangesAsync();
        }


        public async Task<IEnumerable<ForumCategory>> GetAll()
        {
            var response = await _context.ForumCategories
                .Include(f => f.ForumPosts)
                .ToListAsync();
            return response;
        }

        public async Task<ForumCategory> GetById(string id)
        {
            var response = await _context.ForumCategories
               .Include(f => f.ForumPosts)
               .FirstAsync(x => x.ForumCategoryId == id);
            return response;
        }

        public async Task Update(string id, ForumCategory forumCategory)
        {
            _context.Entry(forumCategory).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public async Task Delete(string id)
        {
            ForumCategory forumCategory = await _context.ForumCategories.FindAsync(id);
            _context.ForumCategories.Remove(forumCategory);
            await _context.SaveChangesAsync();
        }

        public bool Exists(string id) =>
            _context.ForumCategories.Any(e => e.ForumCategoryId == id);
    }
}
