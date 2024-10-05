using SIMYTSoacha.Model;
using SIMYTSoacha.Repositories;

namespace SIMYTSoacha.Services
{
    public interface IDocService
    {
        Task<IEnumerable<DocumentsTypes>> GetAllDocAsync();
        Task<DocumentsTypes> GetDocByIdAsync(int id);
        Task CreateDocAsync(DocumentsTypes contact);
        Task UpdateDocAsync(DocumentsTypes contact);
        Task SoftDeleteDoctAsync(int id);
    }

    public class DocService : IDocService
    {
        private readonly IDocRepository _docRepository;

        public DocService(IDocRepository contactRepository)
        {
            _docRepository = contactRepository;
        }

        public async Task<IEnumerable<DocumentsTypes>> GetAllDocAsync()
        {
            return await _docRepository.GetAllDocAsync();
        }

        public async Task<DocumentsTypes> GetDocByIdAsync(int id)
        {
            return await _docRepository.GetDocByIdAsync(id);
        }

        public async Task CreateDocAsync(DocumentsTypes doc)
        {
            await _docRepository.CreateDocAsync(doc);
        }

        public async Task UpdateDocAsync(DocumentsTypes doc)
        {
            await _docRepository.UpdateDocAsync(doc);
        }

        public async Task SoftDeleteDoctAsync(int id)
        {
            await _docRepository.SoftDeleteDocAsync(id);
        }
    }
}
