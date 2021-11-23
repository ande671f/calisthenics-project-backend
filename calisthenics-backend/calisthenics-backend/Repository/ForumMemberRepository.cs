using calisthenics_backend.Database;
using calisthenics_backend.Interface;
using calisthenics_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace calisthenics_backend.Repository
{
    public class ForumMemberRepository : IRepository<ForumMember>
    {
        // dependency injection, scoped
        private readonly Context _context;

        public ForumMemberRepository(Context context)
        {
            _context = context;
        }

        public async Task Create(ForumMember forumMember)
        {
            await _context.ForumMembers.AddAsync(forumMember);
            await _context.SaveChangesAsync();
        }

        public Task Delete(ForumMember _object)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ForumMember>> GetAll()
        {
            throw new NotImplementedException();
        }

        public ForumMember GetById(int id)
        {
            var response = _context.ForumMembers.FirstOrDefault(x => x.Id == id);
            return response;
        }

        public Task Update(ForumMember _object)
        {
            throw new NotImplementedException();
        }
    }
}
