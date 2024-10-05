using Microsoft.EntityFrameworkCore;
using SIMYTSoacha.Context;
using SIMYTSoacha.Model;

namespace SIMYTSoacha.Repositories
{
    public interface ICenterRepository
    {
        Task<IEnumerable<Ecenters>> GetAllCenterAsync();
        Task<Ecenters> GetCenterByIdAsync(int id);
        Task CreateCenterAsync(Ecenters ecenters);
        Task UpdateCenterAsync(Ecenters ecenters);
        Task SoftDeleteCenterAsync(int id);
    }
    public class CenterRepository : ICenterRepository
    {
        private readonly SimytDbContext _context;
        public CenterRepository(SimytDbContext simytDbContext)
        {
            _context = simytDbContext;
        }

        public async Task CreateCenterAsync(Ecenters ecenters)
        {
            _context.Ecenters.AddAsync(ecenters);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Ecenters>> GetAllCenterAsync()
        {
            return await _context.Ecenters
                .Where(s => !s.Isdeleted)
                .ToListAsync();
        }

        public async Task<Ecenters> GetCenterByIdAsync(int id)
        {
            return await _context.Ecenters
                .FirstOrDefaultAsync(s => s.EcenterId == id && !s.Isdeleted);
        }

        public async Task SoftDeleteCenterAsync(int id)
        {
            var center = await _context.Ecenters.FindAsync(id);
            if (center != null)
            {
                center.Isdeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateCenterAsync(Ecenters ecenters)
        {
            _context.Ecenters.Update(ecenters);
            _context.SaveChangesAsync();
        }
    }
}
