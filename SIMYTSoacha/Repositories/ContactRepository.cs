using Microsoft.EntityFrameworkCore;
using SIMYTSoacha.Context;
using SIMYTSoacha.Model;

namespace SIMYTSoacha.Repositories
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contacts>> GetAllContactAsync();
        Task<Contacts> GetContactByIdAsync(int id);
        Task CreateContactAsync(Contacts contact);
        Task UpdateContactAsync(Contacts contact);
        Task SoftDeleteContactAsync(int id);
    }
    public class ContactRepository : IContactRepository
    {
        private readonly SimytDbContext _context;
        public ContactRepository(SimytDbContext context)
        {
            _context = context;
        }
        public async Task CreateContactAsync(Contacts contact)
        {
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Contacts>> GetAllContactAsync()
        {
            return await _context.Contacts
                .Where(s => !s.Isdeleted)
                .Include(t => t.TypesContacts)
                .Include(p => p.People)
                .ToListAsync();
        }

        public async Task<Contacts> GetContactByIdAsync(int id)
        {
            return await _context.Contacts
                .FirstOrDefaultAsync(s => s.ContactId == id && !s.Isdeleted);
        }

        public async Task SoftDeleteContactAsync(int id)
        {
            var subject = await _context.Contacts.FindAsync(id);
            if (subject != null)
            {
                subject.Isdeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateContactAsync(Contacts contact)
        {
            _context.Contacts.Update(contact);
            await _context.SaveChangesAsync();
        }
    }
}
