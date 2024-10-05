using Microsoft.EntityFrameworkCore;
using SIMYTSoacha.Context;
using SIMYTSoacha.Model;

namespace SIMYTSoacha.Repositories
{
    public interface IHistoriesRepository
    {
        Task<IEnumerable<Histories>> GetAllHistoriesAsync();
        Task<Histories> GetHistoriesByIdAsync(int id);
        Task CreateHistoriesAsync(Histories histories);
        Task UpdateHistoriesAsync(Histories Histories);
        Task SoftDeleteHistoriesAsync(int id);  

    }
    public class HistoriesRepository : IHistoriesRepository
    {
        private readonly SimytDbContext _context;
        public HistoriesRepository(SimytDbContext simytDbContext)
        {
            _context = simytDbContext;
        }

        public async Task CreateHistoriesAsync(Histories histories)
        {
            _context.Histories.Add(histories);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Histories>> GetAllHistoriesAsync()
        {
            return await _context.Histories.Where(s => !s.Isdeleted).ToListAsync();
        }

        public async Task<Histories> GetHistoriesByIdAsync(int id)
        {
            return await _context.Histories.FirstOrDefaultAsync(s => s.HistorieId == id && !s.Isdeleted);
        }

        public async Task SoftDeleteHistoriesAsync(int id)
        {
            var historie = await _context.Histories.FindAsync(id);
            if (historie != null)
            {
                historie.Isdeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateHistoriesAsync(Histories Histories)
        {
            _context.Histories.Update(Histories);
            await _context.SaveChangesAsync();
        }
    }
}
