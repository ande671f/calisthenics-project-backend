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

        public Task Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ForumCategory>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<ForumCategory> GetById(string id)
        {
            var response = await _context.ForumCategories
               .FirstAsync(x => x.ForumCategoryId == id);
            return response;
        }

        public Task Update(string id, ForumCategory _object)
        {
            throw new NotImplementedException();
        }
    }
}
