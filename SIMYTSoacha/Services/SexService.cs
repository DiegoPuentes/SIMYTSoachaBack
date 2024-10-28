using SIMYTSoacha.Model;
using SIMYTSoacha.Repositories;

namespace SIMYTSoacha.Services
{
    public interface ISexService
    {
        Task<IEnumerable<Sex>> GetAllSexAsync();
        Task<Sex> GetSexByIdAsync(int id);
        Task<bool> CreateSexAsync(Sex sex);
        Task UpdateSexAsync(Sex sex);
        Task DeleteSexByIdAsync(int id);
    }
    public class SexService : ISexService
    {
        private readonly ISexRepository _repository;
        private readonly IPeopleService _peopleService;
        private readonly IHttpContextAccessor _contextAccessor;
        public SexService(ISexRepository sexRepository, 
            IPeopleService peopleService, IHttpContextAccessor contextAccessor)
        {
            _repository = sexRepository;
            _peopleService = peopleService;
            _contextAccessor = contextAccessor;
        }

        public async Task<bool> CreateSexAsync(Sex sex)
        {
            int? userType = _contextAccessor.HttpContext.Session.GetInt32("UserTypeId");
            if (userType != null)
            {
                if (await _peopleService.PermissionAsync(userType.Value, 1))
                {
                    await _repository.CreateSexAsync(sex); 
                    return true;
                }
                return false;
            }
            return false;
        }

        public Task DeleteSexByIdAsync(int id)
        {
            return _repository.DeleteSexByIdAsync(id);
        }

        public Task<IEnumerable<Sex>> GetAllSexAsync()
        {
            return _repository.GetAllSexAsync();
        }

        public Task<Sex> GetSexByIdAsync(int id)
        {
            return _repository.GetSexByIdAsync(id);
        }

        public Task UpdateSexAsync(Sex sex)
        {
            return _repository.UpdateSexAsync(sex);
        }
    }
}