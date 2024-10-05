using Microsoft.EntityFrameworkCore;
using SIMYTSoacha.Context;
using SIMYTSoacha.Model;

namespace SIMYTSoacha.Repositories
{
    public interface IImpositionRepository
    {
        Task<IEnumerable<Mimpositions>> GetAllMimpositionsAsync();
        Task<Mimpositions> GetMimpositionsByIdAsync(int id);
        Task CreateMimpositionsAsync(Mimpositions mimpositions);
        Task UpdateMimpositionAsync(Mimpositions mimpositions);
        Task SoftDeleteMimpositionsAsync(int id);
    }
    public class ImpositionRepository : IImpositionRepository
    {
        private readonly SimytDbContext _context;
        public ImpositionRepository(SimytDbContext simytDbContext)
        {
            _context = simytDbContext;
        }

        public async Task CreateMimpositionsAsync(Mimpositions mimpositions)
        {
            _context.Mimpositions.Add(mimpositions);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Mimpositions>> GetAllMimpositionsAsync()
        {
            return await _context.Mimpositions
                .Where(s => !s.Isdeleted)
                .ToListAsync();
        }

        public async Task<Mimpositions> GetMimpositionsByIdAsync(int id)
        {
            return await _context.Mimpositions.
                FirstOrDefaultAsync(s => s.MimpositionId == id && !s.Isdeleted);
        }

        public async Task SoftDeleteMimpositionsAsync(int id)
        {
            var impo = await _context.Mimpositions.FindAsync(id);
            if (impo != null)
            {
                impo.Isdeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateMimpositionAsync(Mimpositions mimpositions)
        {
            _context.Mimpositions.Update(mimpositions);
            await _context.SaveChangesAsync();
        }
    }
}
