using Microsoft.EntityFrameworkCore;
using SIMYTSoacha.Context;
using SIMYTSoacha.Model;

namespace SIMYTSoacha.Repositories
{
    public interface ISexRepository
    {
        Task<IEnumerable<Sex>> GetAllSexAsync();
        Task<Sex> GetSexByIdAsync(int id);
        Task CreateSexAsync(Sex sex);
        Task UpdateSexAsync(Sex sex);
        Task DeleteSexByIdAsync(int id);
    }
    public class SexRepository : ISexRepository
    {
        private readonly SimytDbContext _context;
        public SexRepository(SimytDbContext simytDbContext)
        {
            _context = simytDbContext;
        }

        public async Task CreateSexAsync(Sex sex)
        {
            _context.Sexs.Add(sex);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSexByIdAsync(int id)
        {
            var sex = await _context.Sexs.FindAsync(id);
            if (sex != null)
            {
                sex.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Sex>> GetAllSexAsync()
        {
            return await _context.Sexs
                .Where(s => !s.IsDeleted)
                .ToListAsync();
        }

        public async Task<Sex> GetSexByIdAsync(int id)
        {
            return await _context.Sexs.FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);
        }

        public async Task UpdateSexAsync(Sex sex)
        {
            _context.Sexs.Update(sex);
            await _context.SaveChangesAsync();
        }
    }
}
