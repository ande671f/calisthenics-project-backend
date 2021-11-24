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
    public class CommunityMemberRepository : IRepository<CommunityMember>
    {
        // dependency injection, scoped
        private readonly Context _context;

        public CommunityMemberRepository(Context context)
        {
            _context = context;
        }

        public async Task Create(CommunityMember communityMember)
        {
            _context.CommunityMembers.Add(communityMember);
            await _context.SaveChangesAsync();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CommunityMember>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<CommunityMember> GetById(int id)
        {
            var response = await _context.CommunityMembers
                .FirstAsync(x => x.CommunityMemberId == id);
            return response;
        }

        public Task Update(CommunityMember _object)
        {
            throw new NotImplementedException();
        }
    }
}
