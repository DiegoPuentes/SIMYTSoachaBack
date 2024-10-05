using Microsoft.EntityFrameworkCore;
using SIMYTSoacha.Context;
using SIMYTSoacha.Model;

namespace SIMYTSoacha.Repositories
{
    public interface IDocRepository
    {
        Task<IEnumerable<DocumentsTypes>> GetAllDocAsync();
        Task<DocumentsTypes> GetDocByIdAsync(int id);
        Task CreateDocAsync(DocumentsTypes doc);
        Task UpdateDocAsync(DocumentsTypes doc);
        Task SoftDeleteDocAsync(int id);
    }
    public class DocTypeRepository : IDocRepository
    {
        private readonly SimytDbContext _context;
        public DocTypeRepository(SimytDbContext context)
        {
            _context = context;
        }
        public async Task CreateDocAsync(DocumentsTypes doc)
        {
            _context.Dtypes.AddAsync(doc);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DocumentsTypes>> GetAllDocAsync()
        {
            return await _context.Dtypes
                .Where(s => !s.Isdeleted)
                .ToListAsync();
        }

        public async Task<DocumentsTypes> GetDocByIdAsync(int id)
        {
            return await _context.Dtypes
                .FirstOrDefaultAsync(s => s.DtypesId == id && !s.Isdeleted);
        }

        public async Task SoftDeleteDocAsync(int id)
        {
            var subject = await _context.Dtypes.FindAsync(id);
            if (subject != null)
            {
                subject.Isdeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateDocAsync(DocumentsTypes doc)
        {
            _context.Dtypes.Update(doc);
            _context.SaveChangesAsync();
        }
    }
}
