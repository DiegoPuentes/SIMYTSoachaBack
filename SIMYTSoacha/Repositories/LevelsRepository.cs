using Microsoft.EntityFrameworkCore;
using SIMYTSoacha.Context;
using SIMYTSoacha.Model;

namespace SIMYTSoacha.Repositories
{
    public interface ILevelsRepository
    {
        Task<IEnumerable<Levels>> GetAllLevelsAsync();
        Task<Levels> GetLevelsByIdAsync(int id);
        Task CreateLevelsAsync(Levels levels);
        Task SoftDeleteLevelsAsync(int id);
        Task UpdateLevelsAsync(Levels levels);
    }
    public class LevelsRepository : ILevelsRepository
    {
        private readonly SimytDbContext _simytDbContext;
        public LevelsRepository(SimytDbContext simytDbContext)
        {
            _simytDbContext = simytDbContext;
        }

        public async Task CreateLevelsAsync(Levels levels)
        {
            _simytDbContext.Levels.Add(levels);
            await _simytDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Levels>> GetAllLevelsAsync()
        {
            return await _simytDbContext.Levels.
                Where(s => !s.IsDeleted)
                .ToListAsync();
        }

        public async Task<Levels> GetLevelsByIdAsync(int id)
        {
            return await _simytDbContext.Levels.FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);
        }

        public async Task SoftDeleteLevelsAsync(int id)
        {
            var level = await _simytDbContext.Levels.FindAsync(id);
            if (level != null)
            {
                level.IsDeleted = true;
                await _simytDbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateLevelsAsync(Levels levels)
        {
            _simytDbContext.Levels.Update(levels);
            await _simytDbContext.SaveChangesAsync();
        }
    }
}
