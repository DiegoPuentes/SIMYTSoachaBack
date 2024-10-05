using Microsoft.EntityFrameworkCore;
using SIMYTSoacha.Context;
using SIMYTSoacha.Model;

namespace SIMYTSoacha.Repositories
{
    public interface ITserviceRepository
    {
        Task<IEnumerable<TypesServices>> GetAllTserviceAsync();
        Task<TypesServices> GetTserviceByIdAsync(int id);
        Task CreateTserviceAsync(TypesServices types);
        Task UpdateTserviceAsync(TypesServices types);
        Task SoftDeleteTserviceAsync(int id);
    }
    public class TserviceRepository : ITserviceRepository
    {
        private readonly SimytDbContext _context;
        public TserviceRepository(SimytDbContext simytDbContext)
        {
            _context = simytDbContext;
        }

        public async Task CreateTserviceAsync(TypesServices types)
        {
            _context.TypesServices.Add(types);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TypesServices>> GetAllTserviceAsync()
        {
            return await _context.TypesServices.
                Where(s => !s.Isdeleted)
                .ToListAsync();
        }

        public async Task<TypesServices> GetTserviceByIdAsync(int id)
        {
            return await _context.TypesServices
                .FirstOrDefaultAsync(s => s.TservicesId == id && !s.Isdeleted);
        }

        public async Task SoftDeleteTserviceAsync(int id)
        {
            var tser = await _context.TypesServices.FindAsync(id);
            if (tser != null)
            {
                tser.Isdeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateTserviceAsync(TypesServices types)
        {
            _context.TypesServices.Update(types);
            await _context.SaveChangesAsync();
        }
    }
}
