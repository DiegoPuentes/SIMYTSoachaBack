using SIMYTSoacha.Model;
using SIMYTSoacha.Repositories;

namespace SIMYTSoacha.Services
{
    public interface IDocService
    {
        Task<IEnumerable<DocumentsTypes>> GetAllDocAsync();
        Task<DocumentsTypes> GetDocByIdAsync(int id);
        Task<bool> CreateDocAsync(DocumentsTypes contact);
        Task UpdateDocAsync(DocumentsTypes contact);
        Task SoftDeleteDoctAsync(int id);
    }

    public class DocService : IDocService
    {
        private readonly IDocRepository _docRepository;
        private readonly IPeopleService _peopleService;
        private readonly IHttpContextAccessor _contextAccessor;
        public DocService(IDocRepository contactRepository, IPeopleService peopleService,
            IHttpContextAccessor httpContextAccessor)
        {
            _docRepository = contactRepository;
            _peopleService = peopleService;
            _contextAccessor = httpContextAccessor;
        }

        public async Task<IEnumerable<DocumentsTypes>> GetAllDocAsync()
        {
            return await _docRepository.GetAllDocAsync();
        }

        public async Task<DocumentsTypes> GetDocByIdAsync(int id)
        {
            return await _docRepository.GetDocByIdAsync(id);
        }

        public async Task<bool> CreateDocAsync(DocumentsTypes doc)
        {
            int? userType = _contextAccessor.HttpContext.Session.GetInt32("UserTypeId");
            if (userType != null)
            {
                if (await _peopleService.PermissionAsync(userType.Value, 1))
                {
                    await _docRepository.CreateDocAsync(doc); ;
                    return true;
                }
                return false;
            }
            return false;
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
