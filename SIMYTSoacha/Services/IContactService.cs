using SIMYTSoacha.Model;
using SIMYTSoacha.Repositories;

namespace SIMYTSoacha.Services
{
    public interface IContactService
    {
        Task<IEnumerable<DocumentsTypes>> GetAllContactAsync();
        Task<DocumentsTypes> GetContactByIdAsync(int id);
        Task CreateContactAsync(DocumentsTypes contact);
        Task UpdateContactAsync(DocumentsTypes contact);
        Task SoftDeleteContactAsync(int id);
    }

    public class DocService : IContactService
    {
        private readonly IDocRepository _docRepository;

        public DocService(IDocRepository docRepository)
        {
            _docRepository = docRepository;
        }

        public async Task<IEnumerable<DocumentsTypes>> GetAllContactAsync()
        {
            return await _docRepository.GetAllContactAsync();
        }

        public async Task<DocumentsTypes> GetContactByIdAsync(int id)
        {
            return await _docRepository.GetContactByIdAsync(id);
        }

        public async Task CreateContactAsync(DocumentsTypes doc)
        {
            await _docRepository.CreateContactAsync(doc);
        }

        public async Task UpdateContactAsync(DocumentsTypes doc)
        {
            await _docRepository.UpdateContactAsync(doc);
        }

        public async Task SoftDeleteContactAsync(int id)
        {
            await _docRepository.SoftDeleteContactAsync(id);
        }
    }
}
