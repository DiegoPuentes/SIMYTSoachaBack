using Microsoft.EntityFrameworkCore;
using SIMYTSoacha.Context;
using SIMYTSoacha.Model;

namespace SIMYTSoacha.Repositories
{
    public interface IMxLRepository
    {
        Task<IEnumerable<ModelXLine>> GetAllAsync();
        Task CreateAsync(ModelXLine model);
    }
    public class MxLRepository : IMxLRepository
    {
        private readonly SimytDbContext _context;
        public MxLRepository(SimytDbContext simytDbContext) 
        {
            _context = simytDbContext;
        }

        public async Task CreateAsync(ModelXLine model)
        {
            _context.ModelXLines.Add(model);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ModelXLine>> GetAllAsync()
        {
            return await _context.ModelXLines
                .Where(s => !s.Isdeleted)
                .Include(l => l.Line)
                .Include(m => m.Models)
                .ToListAsync();
        }
    }
}
