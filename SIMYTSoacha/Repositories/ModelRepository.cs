using Microsoft.EntityFrameworkCore;
using SIMYTSoacha.Context;
using SIMYTSoacha.Model;

namespace SIMYTSoacha.Repositories
{
    public interface IModelRepository
    {
        Task<IEnumerable<Models>> GetAllModelAsync();
        Task<Models> GetModelByIdAsync(int id);
        Task CreateModelAsync(Models model);
        Task UpdateModelAsync(Models model);    
        Task SoftDeleteModelAsync(int id);
    }
    public class ModelRepository : IModelRepository
    {
        private readonly SimytDbContext _context;
        public ModelRepository(SimytDbContext simytDbContext)
        {
            _context = simytDbContext;
        }

        public async Task CreateModelAsync(Models model)
        {
            _context.Models.Add(model);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Models>> GetAllModelAsync()
        {
            return await _context.Models
                .Where(s => !s.Isdeleted)
                .ToListAsync();
        }

        public async Task<Models> GetModelByIdAsync(int id)
        {
            return await _context.Models
                .FirstOrDefaultAsync(s => s.Id == id && !s.Isdeleted);
        }

        public async Task SoftDeleteModelAsync(int id)
        {
            var model = await _context.Models.FindAsync(id);
            if (model != null)
            {
                model.Isdeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateModelAsync(Models model)
        {
            _context.Models.Update(model);
            await _context.SaveChangesAsync();
        }
    }
}
