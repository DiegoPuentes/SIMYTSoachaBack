using SIMYTSoacha.Model;
using SIMYTSoacha.Repositories;

namespace SIMYTSoacha.Services
{
    public interface IImpositionService
    {
        Task<IEnumerable<Mimpositions>> GetAllMimpositionsAsync();
        Task<Mimpositions> GetMimpositionsByIdAsync(int id);
        Task<bool> CreateMimpositionsAsync(Mimpositions mimpositions);
        Task UpdateMimpositionAsync(Mimpositions mimpositions);
        Task SoftDeleteMimpositionsAsync(int id);
    }
    public class ImpositionService : IImpositionService
    {
        private readonly IImpositionRepository _repository;
        private readonly IPeopleService _peopleService;
        private readonly IHttpContextAccessor _contextAccessor;
        public ImpositionService(IImpositionRepository impositionRepository, 
            IPeopleService peopleService, IHttpContextAccessor httpContextAccessor)
        {
            _repository = impositionRepository;
            _peopleService = peopleService;
            _contextAccessor = httpContextAccessor;
        }

        public async Task<bool> CreateMimpositionsAsync(Mimpositions mimpositions)
        {
            int? userType = _contextAccessor.HttpContext.Session.GetInt32("UserTypeId");
            if (userType != null)
            {
                if (await _peopleService.PermissionAsync(userType.Value, 1))
                {
                    await _repository.CreateMimpositionsAsync(mimpositions);
                    return true;
                }
                return false;
            }
            return false;
        }

        public Task<IEnumerable<Mimpositions>> GetAllMimpositionsAsync()
        {
            return _repository.GetAllMimpositionsAsync();
        }

        public Task<Mimpositions> GetMimpositionsByIdAsync(int id)
        {
            return _repository.GetMimpositionsByIdAsync(id);
        }

        public Task SoftDeleteMimpositionsAsync(int id)
        {
            return _repository.SoftDeleteMimpositionsAsync(id);
        }

        public Task UpdateMimpositionAsync(Mimpositions mimpositions)
        {
            return _repository.UpdateMimpositionAsync(mimpositions);
        }
    }
}
