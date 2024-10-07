using Microsoft.EntityFrameworkCore;
using SIMYTSoacha.Context;
using SIMYTSoacha.Model;

namespace SIMYTSoacha.Repositories
{
    public interface IDocRepository
    {
        Task<IEnumerable<DocumentsTypes>> GetAllContactAsync();
        Task<DocumentsTypes> GetContactByIdAsync(int id);
        Task CreateContactAsync(DocumentsTypes contact);
        Task UpdateContactAsync(DocumentsTypes contact);
        Task SoftDeleteContactAsync(int id);
    }
    public class ContactRepository : IDocRepository
    {
        private readonly SimytDbContext _context;
        public ContactRepository(SimytDbContext context)
        {
            _context = context;
        }
        public async Task CreateContactAsync(DocumentsTypes contact)
        {
            _context.Contacts.Add(contact);
            await _context.SaveChanges();
        }

        public async Task<IEnumerable<DocumentsTypes>> GetAllContactAsync()
        {
            return await _context.Contacts
                .Where(s => !s.Isdeleted)
                .ToListAsync();
        }

        public async Task<DocumentsTypes> GetContactByIdAsync(int id)
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

        public async Task UpdateContactAsync(DocumentsTypes contact)
        {
            _context.Contacts.Update(contact);
            _context.SaveChangesAsync();
        }
    }
}
