using Microsoft.EntityFrameworkCore;
using SIMYTSoacha.Context;
using SIMYTSoacha.Model;

namespace SIMYTSoacha.Repositories
{
    public interface IPeopleRepository
    {
        Task<IEnumerable<People>> GetAllPeopleAsync();
        Task<People> GetSubjectByIdAsync(int id);
        Task CreatePeopleAsync(People person);
        Task UpdatePeopleAsync(People person);
        Task SoftDeletePeopleAsync(int id);
    }
    public class PeopleRepository : IPeopleRepository
    {
        private readonly SimytDbContext _context;
        public PeopleRepository(SimytDbContext context)
        {
            _context = context;
        }
        public async Task CreatePeopleAsync(People person)
        {
            _context.People.Add(person);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<People>> GetAllPeopleAsync()
        {
            return await _context.People
                .Where(s => !s.Isdeleted)
                .ToListAsync();
        }

        public async Task<People> GetSubjectByIdAsync(int id)
        {
            return await _context.People
                .FirstOrDefaultAsync(s => s.PeopleId == id && !s.Isdeleted);
        }

        public async Task SoftDeletePeopleAsync(int id)
        {
            var subject = await _context.People.FindAsync(id);
            if (subject != null)
            {
                subject.Isdeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdatePeopleAsync(People person)
        {
            _context.People.Update(person);
            _context.SaveChangesAsync();
        }
    }
}
