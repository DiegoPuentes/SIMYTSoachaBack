using Microsoft.EntityFrameworkCore;
using SIMYTSoacha.Context;
using SIMYTSoacha.Model;

namespace SIMYTSoacha.Repositories
{
    public interface IFinesRepository
    {
        Task<IEnumerable<Fines>> GetAllFinesAsync();
        Task<Fines> GetFinesByIdAsync(int id);
        Task<Fines> CreateFinesAsync(int id, int mid, int pid, bool isdeleted);
        Task UpdateFinesAsync(int id, int mid, int pid, bool isdeleted);
        Task SoftDeleteFinesAsync(int id);
    }
    public class FinesRepository : IFinesRepository
    {
        private readonly SimytDbContext _context;
        public FinesRepository(SimytDbContext context)
        {
            _context = context;
        }

        public async Task<Fines> CreateFinesAsync(int id, int mid, int pid, bool isdeleted)
        {
            Fines fine = new Fines 
            { 
                InfractionId = id,
                Infractions = null,
                MimpositionId = mid,
                Mimpositions = null,
                ProcedureId = pid,
                Procedures = null,
                Isdeleted = isdeleted
            };
            _context.Fines.Add(fine);
            await _context.SaveChangesAsync();
            return fine;
        }

        public async Task<IEnumerable<Fines>> GetAllFinesAsync()
        {
            return await _context.Fines
                .Where(s => !s.Isdeleted)
                .Include(i => i.Infractions)
                .Include(m => m.Mimpositions)
                .Include(p => p.Procedures)
                .ToListAsync();
        }

        public async Task<Fines> GetFinesByIdAsync(int id)
        {
            return await _context.Fines
                .FirstOrDefaultAsync(s => s.FinesId == id && !s.Isdeleted);
        }

        public async Task SoftDeleteFinesAsync(int id)
        {
            var fines = await _context.Fines.FindAsync(id);
            if (fines != null)
            {
                fines.Isdeleted = true;
                await _context.SaveChangesAsync();
            }

        }

        public async Task UpdateFinesAsync(int id, int mid, int pid, bool isdeleted)
        {
            Fines fine = new Fines
            {
                InfractionId = id,
                Infractions = null,
                MimpositionId = mid,
                Mimpositions = null,
                ProcedureId = pid,
                Procedures = null,
                Isdeleted = isdeleted
            };
            _context.Fines.Update(fine);
            await _context.SaveChangesAsync();
        }
    }
}
