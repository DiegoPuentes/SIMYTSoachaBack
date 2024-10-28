using SIMYTSoacha.Model;
using SIMYTSoacha.Repositories;

namespace SIMYTSoacha.Services
{
    public interface IContactService
    {
        Task<IEnumerable<Contacts>> GetAllContactAsync();
        Task<Contacts> GetContactByIdAsync(int id);
        Task<bool> CreateContactAsync(Contacts contact);
        Task UpdateContactAsync(Contacts contact);
        Task SoftDeleteContactAsync(int id);
    }

    public class ContactService : IContactService
    {
        private readonly IContactRepository _contRepository;
        private readonly IPeopleService _peopleService;
        private readonly IHttpContextAccessor _contextAccessor;

        public ContactService(IContactRepository conRepository, IPeopleService peopleService,
            IHttpContextAccessor httpContextAccessor)
        {
            _contRepository = conRepository;
            _peopleService = peopleService;
            _contextAccessor = httpContextAccessor;
        }

        public async Task<IEnumerable<Contacts>> GetAllContactAsync()
        {
            return await _contRepository.GetAllContactAsync();
        }

        public async Task<Contacts> GetContactByIdAsync(int id)
        {
            return await _contRepository.GetContactByIdAsync(id);
        }

        public async Task<bool> CreateContactAsync(Contacts doc)
        {
            int? userType = _contextAccessor.HttpContext.Session.GetInt32("UserTypeId");
            if (userType != null)
            {
                if (await _peopleService.PermissionAsync(userType.Value, 1))
                {
                    await _contRepository.CreateContactAsync(doc);
                    return true;
                }
                return false;
            }
            return false;
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
