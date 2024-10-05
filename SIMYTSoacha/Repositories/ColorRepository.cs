using Microsoft.EntityFrameworkCore;
using SIMYTSoacha.Context;
using SIMYTSoacha.Model;

namespace SIMYTSoacha.Repositories
{
    public interface IColorRepository
    {
        Task<IEnumerable<Colors>> GetAllColorAsync();
        Task<Colors> GetColorByIdAsync(int id);
        Task CreateColorAsync(Colors colors);
        Task UpdateColorAsync(Colors colors);
        Task SoftDeleteColorAsync(int id);
    }
    public class ColorRepository : IColorRepository
    {
        private readonly SimytDbContext _simytDbContext;
        public ColorRepository(SimytDbContext simytDbContext)
        {
            _simytDbContext = simytDbContext;
        }

        public async Task CreateColorAsync(Colors colors)
        {
            _simytDbContext.Colors.Add(colors);
            await _simytDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Colors>> GetAllColorAsync()
        {
           return await _simytDbContext.Colors.
                Where(s => !s.IsDeleted)
                .ToListAsync();
        }

        public async Task<Colors> GetColorByIdAsync(int id)
        {
            return await _simytDbContext.Colors
                .FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);
        }

        public async Task SoftDeleteColorAsync(int id)
        {
            var color = await _simytDbContext.Colors.FindAsync(id);
            if (color != null)
            {
                color.IsDeleted = true;
                await _simytDbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateColorAsync(Colors colors)
        {
            _simytDbContext.Colors.Update(colors);
            _simytDbContext.SaveChangesAsync();
        }
    }
}
