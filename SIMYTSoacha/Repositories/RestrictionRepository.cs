using Microsoft.EntityFrameworkCore;
using SIMYTSoacha.Context;
using SIMYTSoacha.Model;

namespace SIMYTSoacha.Repositories
{
    public interface IRestrictionRepository
    {
        Task<IEnumerable<Restrictions>> GetAllRestriAsync();
        Task<Restrictions> GetRestriByIdAsync(int id);
        Task CreateRestriAsync(Restrictions restri);
        Task UpdateRestriAsync(Restrictions restri);
        Task SoftDeleteRestriAsync(int id);
    }
    public class RestrictionRepository : IRestrictionRepository
    {
        private readonly SimytDbContext _context;
        public RestrictionRepository(SimytDbContext simytDbContext)
        {
            _context = simytDbContext;
        }
        public async Task CreateRestriAsync(Restrictions restri)
        {
            _context.Restrictions.Add(restri);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Restrictions>> GetAllRestriAsync()
        {
            return await _context.Restrictions
                .Where(s => !s.Isdeleted)
                .ToListAsync();
        }

        public async Task<Restrictions> GetRestriByIdAsync(int id)
        {
            return await _context.Restrictions
                .FirstOrDefaultAsync(s => s.RestrictionId == id && !s.Isdeleted);
        }

        public async Task SoftDeleteRestriAsync(int id)
        {
            var restri = await _context.Restrictions.FindAsync(id);
            if (restri != null)
            {
                restri.Isdeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateRestriAsync(Restrictions restri)
        {
            _context.Restrictions.Update(restri);
            await _context.SaveChangesAsync();
        }
    }
}
