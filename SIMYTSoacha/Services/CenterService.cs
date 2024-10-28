using SIMYTSoacha.Model;
using SIMYTSoacha.Repositories;

namespace SIMYTSoacha.Services
{
    public interface ICenterService
    {
        Task<IEnumerable<Ecenters>> GetAllCenterAsync();
        Task<Ecenters> GetCenterByIdAsync(int id);
        Task<bool> CreateCenterAsync(Ecenters ecenters);
        Task UpdateCenterAsync(Ecenters ecenters);
        Task SoftDeleteCenterAsync(int id);
    }

    public class CenterService : ICenterService
    {
        private readonly ICenterRepository _centerRepository;
        private readonly IPeopleService _peopleService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CenterService(ICenterRepository centerRepository,
            IPeopleService peopleService, IHttpContextAccessor httpContextAccessor)
        {
            _centerRepository = centerRepository;
            _peopleService = peopleService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> CreateCenterAsync(Ecenters ecenters)
        {
            int? userType = _httpContextAccessor.HttpContext.Session.GetInt32("UserTypeId");
            if (userType != null)
            {
                if (await _peopleService.PermissionAsync(userType.Value, 1))
                {
                    await _centerRepository.CreateCenterAsync(ecenters);
                    return true;
                }
                return false;
            }
            return false;
        }

        public Task<IEnumerable<Ecenters>> GetAllCenterAsync()
        {
            return _centerRepository.GetAllCenterAsync();
        }

        public Task<Ecenters> GetCenterByIdAsync(int id)
        {
            return _centerRepository.GetCenterByIdAsync(id);
        }

        public Task SoftDeleteCenterAsync(int id)
        {
            return _centerRepository.SoftDeleteCenterAsync(id);
        }

        public Task UpdateCenterAsync(Ecenters ecenters)
        {
            return _centerRepository.UpdateCenterAsync(ecenters);
        }
    }
}
