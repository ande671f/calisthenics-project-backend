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

        public async Task Delete(string id)
        {
            var communityMember = await _context.CommunityMembers.FindAsync(id);

            //if (forumMember == null)
            //{
            //	return NotFound();
            //}

            _context.CommunityMembers.Remove(communityMember);
            await _context.SaveChangesAsync();

            //return NoContent();
        }

        public async Task<IEnumerable<CommunityMember>> GetAll()
        {
            var response = await _context.CommunityMembers
                .ToListAsync();
            return response;
        }

        public async Task<CommunityMember> GetById(string id)
        {
            var response = await _context.CommunityMembers
                .FirstAsync(x => x.CommunityMemberId == id);
            return response;
        }

        public async Task Update(string id, CommunityMember communityMember)
        {
            //if (id != todoItem.Id)
            //{
            //    return BadRequest();
            //}

            _context.Entry(communityMember).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommunityMemberExists(id))
                {
                    //return NotFound();
                }
                else
                {
                    throw;
                }
            }

            //return NoContent();
        }

        private bool CommunityMemberExists(string id)
        {
            return _context.CommunityMembers.Any(e => e.CommunityMemberId == id);
        }
    }
}
