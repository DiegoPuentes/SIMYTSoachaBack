using SIMYTSoacha.Model;
using SIMYTSoacha.Repositories;

namespace SIMYTSoacha.Services
{
    public interface ITserviceService
    {
        Task<IEnumerable<TypesServices>> GetAllTserviceAsync();
        Task<TypesServices> GetTserviceByIdAsync(int id);
        Task<bool> CreateTserviceAsync(TypesServices types);
        Task UpdateTserviceAsync(TypesServices types);
        Task SoftDeleteTserviceAsync(int id);
    }
    public class TserviceService : ITserviceService
    {
        private readonly ITserviceRepository _repository;
        private readonly IPeopleService _peopleService;
        private readonly IHttpContextAccessor _contextAccessor;
        public TserviceService(ITserviceRepository tserviceRepository, IPeopleService peopleService
            ,IHttpContextAccessor httpContextAccessor)
        {
            _repository = tserviceRepository;
            _peopleService = peopleService;
            _contextAccessor = httpContextAccessor;
        }

        public async Task<bool> CreateTserviceAsync(TypesServices types)
        {
            int? userType = _contextAccessor.HttpContext.Session.GetInt32("UserTypeId");
            if (userType != null)
            {
                if (await _peopleService.PermissionAsync(userType.Value, 1))
                {
                    await _repository.CreateTserviceAsync(types);
                    return true;
                }
                return false;
            }
            return false;
        }

        public Task<IEnumerable<TypesServices>> GetAllTserviceAsync()
        {
            return _repository.GetAllTserviceAsync();
        }

        public Task<TypesServices> GetTserviceByIdAsync(int id)
        {
            return _repository.GetTserviceByIdAsync(id);
        }

        public Task SoftDeleteTserviceAsync(int id)
        {
            return _repository.SoftDeleteTserviceAsync(id);
        }

        public Task UpdateTserviceAsync(TypesServices types)
        {
            return _repository.UpdateTserviceAsync(types);
        }
    }
}
