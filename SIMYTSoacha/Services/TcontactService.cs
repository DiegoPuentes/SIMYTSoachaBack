using SIMYTSoacha.Model;
using SIMYTSoacha.Repositories;

namespace SIMYTSoacha.Services
{
    public interface ITcontactService
    {
        Task<IEnumerable<TypesContacts>> GetAllTcontactAsync();
        Task<TypesContacts> GetTcontactByIdAsync(int id);
        Task<bool> CreateTcontactAsync(TypesContacts types);
        Task UpdateTcontactAsync(TypesContacts types);
        Task SoftDeleteTcontactAsync(int id);
    }
    public class TcontactService : ITcontactService
    {
        private readonly ITcontactRepository _contactRepository;
        private readonly IPeopleService _peopleService;
        private readonly IHttpContextAccessor _contextAccessor;
        public TcontactService(ITcontactRepository tcontactRepository, IPeopleService peopleService,
            IHttpContextAccessor httpContextAccessor)
        {
            _contactRepository = tcontactRepository;    
            _peopleService = peopleService;
            _contextAccessor = httpContextAccessor;
        }

        public async Task<bool> CreateTcontactAsync(TypesContacts types)
        {
            int? userType = _contextAccessor.HttpContext.Session.GetInt32("UserTypeId");
            if (userType != null)
            {
                if (await _peopleService.PermissionAsync(userType.Value, 1))
                {
                    await _contactRepository.CreateTcontactAsync(types);
                    return true;
                }
                return false;
            }
            return false;
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
