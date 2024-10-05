using SIMYTSoacha.Model;
using SIMYTSoacha.Repositories;

namespace SIMYTSoacha.Services
{
    public interface ITcontactService
    {
        Task<IEnumerable<TypesContacts>> GetAllTcontactAsync();
        Task<TypesContacts> GetTcontactByIdAsync(int id);
        Task CreateTcontactAsync(TypesContacts types);
        Task UpdateTcontactAsync(TypesContacts types);
        Task SoftDeleteTcontactAsync(int id);
    }
    public class TcontactService : ITcontactService
    {
        private readonly ITcontactRepository _contactRepository;
        public TcontactService(ITcontactRepository tcontactRepository)
        {
            _contactRepository = tcontactRepository;    
        }

        public Task CreateTcontactAsync(TypesContacts types)
        {
            return _contactRepository.CreateTcontactAsync(types);
        }

        public Task<IEnumerable<TypesContacts>> GetAllTcontactAsync()
        {
            return _contactRepository.GetAllTcontactAsync();
        }

        public Task<TypesContacts> GetTcontactByIdAsync(int id)
        {
            return _contactRepository.GetTcontactByIdAsync(id);
        }

        public Task SoftDeleteTcontactAsync(int id)
        {
            return _contactRepository.SoftDeleteTcontactAsync(id);
        }

        public Task UpdateTcontactAsync(TypesContacts types)
        {
            return _contactRepository.UpdateTcontactAsync(types);
        }
    }
}
