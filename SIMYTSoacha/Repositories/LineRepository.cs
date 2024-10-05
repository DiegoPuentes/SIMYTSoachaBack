using Microsoft.EntityFrameworkCore;
using SIMYTSoacha.Context;
using SIMYTSoacha.Model;

namespace SIMYTSoacha.Repositories
{
    public interface ILineRepository
    {
        Task<IEnumerable<Lines>> GetAllLinesAsync();
        Task<Lines> GetLinesByIdAsync(int id);
        Task CreateLinesAsync(Lines line);
        Task UpdateLinesAsync(Lines line);
        Task SoftDeleteLinesAsync(int id);
    }
    public class LineRepository : ILineRepository
    {
        private readonly SimytDbContext _simytDbContext;
        public LineRepository(SimytDbContext simytDbContext)
        {
            _simytDbContext = simytDbContext;
        }

        public async Task CreateLinesAsync(Lines line)
        {
            _simytDbContext.Lines.Add(line);
            await _simytDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Lines>> GetAllLinesAsync()
        {
            return await _simytDbContext.Lines
                .Where(s => !s.Isdeleted)
                .ToListAsync();
        }

        public async Task<Lines> GetLinesByIdAsync(int id)
        {
            return await _simytDbContext.Lines
                .FirstOrDefaultAsync(s => s.Id == id && !s.Isdeleted);
        }

        public async Task SoftDeleteLinesAsync(int id)
        {
            var line = await _simytDbContext.Lines.FindAsync(id);
            if (line != null)
            {
                line.Isdeleted = true;
                await _simytDbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateLinesAsync(Lines line)
        {
            _simytDbContext.Lines.Update(line);
            await _simytDbContext.SaveChangesAsync();
        }
    }
}
