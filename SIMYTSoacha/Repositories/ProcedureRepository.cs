using Microsoft.EntityFrameworkCore;
using SIMYTSoacha.Context;
using SIMYTSoacha.Model;

namespace SIMYTSoacha.Repositories
{
    public interface IProcedureRepository
    {
        Task<IEnumerable<Procedures>> GetAllProceduresAsync();
        Task<Procedures> GetProceduresByIdAsync(int id);
        Task<Procedures> CreateProceduresAsync(string p, int sid, int rid, bool isde);
        Task UpdateProceduresAsync(Procedures procedures);
        Task SoftDeleteProceduresAsync(int id);
    }
    public class ProcedureRepository : IProcedureRepository
    {
        private readonly SimytDbContext _context;
        public ProcedureRepository(SimytDbContext simytDbContext)
        {
            _context = simytDbContext;
        }

        public async Task<Procedures> CreateProceduresAsync(string p, int sid, int rid, bool isde)
        {
            Procedures procedures = new Procedures
            {
                Description = p,
                StateId = sid,
                States = null,
                RequestId = sid,
                Requests = null,
                Isdeleted = isde
            };
            _context.Procedures.Add(procedures);
            await _context.SaveChangesAsync();
            return procedures;
        }

        public async Task<IEnumerable<Procedures>> GetAllProceduresAsync()
        {
            return await _context.Procedures
                .Where(s => !s.Isdeleted)
                .Include(r => r.States)
                .Include(r => r.Requests)
                .ThenInclude(p => p.People)
                .Include(r => r.Requests)
                .ThenInclude(p => p.Officer)
                .ToListAsync();
        }

        public async Task<Procedures> GetProceduresByIdAsync(int id)
        {
            return await _context.Procedures
                .FirstOrDefaultAsync(s => s.ProcedureId == id && !s.Isdeleted);
        }

        public async Task SoftDeleteProceduresAsync(int id)
        {
            var procedure = await _context.Procedures.FindAsync(id);
            if (procedure != null)
            {
                procedure.Isdeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateProceduresAsync(Procedures procedures)
        {
            _context.Procedures.Update(procedures);
            await _context.SaveChangesAsync();
        }
    }
}
