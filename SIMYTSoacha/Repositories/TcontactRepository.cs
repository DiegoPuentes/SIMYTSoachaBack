using Microsoft.EntityFrameworkCore;
using SIMYTSoacha.Context;
using SIMYTSoacha.Model;

namespace SIMYTSoacha.Repositories
{
    public interface ITcontactRepository
    {
        Task<IEnumerable<TypesContacts>> GetAllTcontactAsync();
        Task<TypesContacts> GetTcontactByIdAsync(int id);
        Task CreateTcontactAsync(TypesContacts types);
        Task UpdateTcontactAsync(TypesContacts types);
        Task SoftDeleteTcontactAsync(int id);
    }
    public class TcontactRepository : ITcontactRepository
    {
        private readonly SimytDbContext _context;
        public TcontactRepository(SimytDbContext simytDbContext)
        {
            _context = simytDbContext;
        }
        public async Task CreateTcontactAsync(TypesContacts types)
        {
            _context.TypesContacts.Add(types);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TypesContacts>> GetAllTcontactAsync()
        {
            return await _context.TypesContacts
                .Where(s => !s.Isdeleted)
                .ToListAsync();
        }

        public async Task<TypesContacts> GetTcontactByIdAsync(int id)
        {
            return await _context.TypesContacts
                .FirstOrDefaultAsync(s => s.TcontactId == id && !s.Isdeleted);
        }

        public async Task SoftDeleteTcontactAsync(int id)
        {
            var tcont = await _context.TypesContacts.FindAsync(id);
            if (tcont != null)
            {
                tcont.Isdeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateTcontactAsync(TypesContacts types)
        {
            _context.TypesContacts.Update(types);
            await _context.SaveChangesAsync();
        }
    }
}
