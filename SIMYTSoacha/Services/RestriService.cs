using SIMYTSoacha.Model;
using SIMYTSoacha.Repositories;

namespace SIMYTSoacha.Services
{
    public interface IRestriService
    {
        Task<IEnumerable<Restrictions>> GetAllRestriAsync();
        Task<Restrictions> GetRestriByIdAsync(int id);
        Task<bool> CreateRestriAsync(Restrictions restri);
        Task UpdateRestriAsync(Restrictions restri);
        Task SoftDeleteRestriAsync(int id);
    }

    public class RestriService : IRestriService
    {
        private readonly IRestrictionRepository _restrictionRepository;
        private readonly IPeopleService _peopleService;
        private readonly IHttpContextAccessor _contextAccessor;
        public RestriService(IRestrictionRepository restrictionRepository, 
            IPeopleService peopleService, IHttpContextAccessor contextAccessor)
        {
            _restrictionRepository = restrictionRepository;
            _peopleService = peopleService;
            _contextAccessor = contextAccessor;
        }

        public async Task<bool> CreateRestriAsync(Restrictions restri)
        {
            int? userType = _contextAccessor.HttpContext.Session.GetInt32("UserTypeId");
            if (userType != null)
            {
                if (await _peopleService.PermissionAsync(userType.Value, 1))
                {
                    await _restrictionRepository.CreateRestriAsync(restri);
                    return true;
                }
                return false;
            }
            return false;
        }

        public Task<IEnumerable<Restrictions>> GetAllRestriAsync()
        {
            return _restrictionRepository.GetAllRestriAsync();
        }

        public Task<Restrictions> GetRestriByIdAsync(int id)
        {
            return _restrictionRepository.GetRestriByIdAsync(id);
        }

        public Task SoftDeleteRestriAsync(int id)
        {
            return _restrictionRepository.SoftDeleteRestriAsync(id);
        }

        public Task UpdateRestriAsync(Restrictions restri)
        {
            return _restrictionRepository.UpdateRestriAsync(restri);
        }
    }
}
