using SIMYTSoacha.Model;
using SIMYTSoacha.Repositories;

namespace SIMYTSoacha.Services
{
    public interface IContactService
    {
        Task<IEnumerable<Contacts>> GetAllContactAsync();
        Task<Contacts> GetContactByIdAsync(int id);
        Task CreateContactAsync(Contacts contact);
        Task UpdateContactAsync(Contacts contact);
        Task SoftDeleteContactAsync(int id);
    }

    public class ContactService : IContactService
    {
        private readonly IContactRepository _contRepository;

        public ContactService(ContactRepository conRepository)
        {
            _contRepository = conRepository;
        }

        public async Task<IEnumerable<Contacts>> GetAllContactAsync()
        {
            return await _contRepository.GetAllContactAsync();
        }

        public async Task<Contacts> GetContactByIdAsync(int id)
        {
            return await _contRepository.GetContactByIdAsync(id);
        }

        public async Task CreateContactAsync(Contacts doc)
        {
            await _contRepository.CreateContactAsync(doc);
        }

        public async Task UpdateContactAsync(Contacts doc)
        {
            await _contRepository.UpdateContactAsync(doc);
        }

        public async Task SoftDeleteContactAsync(int id)
        {
            await _contRepository.SoftDeleteContactAsync(id);
        }
    }
}
