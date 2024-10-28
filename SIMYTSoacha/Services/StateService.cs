using SIMYTSoacha.Model;
using SIMYTSoacha.Repositories;

namespace SIMYTSoacha.Services
{
    public interface IStateService
    {
        Task<IEnumerable<States>> GetAllStatesAsync();
        Task<States> GetStatesByIdAsync(int id);
        Task<bool> CreateStateAsync(States states);
        Task UpdateStateAsync(States states);
        Task SoftDeleteStateAsync(int id);
    }
    public class StateService : IStateService
    {
        private readonly IStateRepository _stateRepository;
        private readonly IPeopleService _peopleService;
        private readonly IHttpContextAccessor _contextAccessor;
        public StateService(IStateRepository state, 
            IPeopleService peopleService, IHttpContextAccessor contextAccessor)
        {
            _stateRepository = state;
            _peopleService = peopleService;
            _contextAccessor = contextAccessor;
        }

        public async Task<bool> CreateStateAsync(States states)
        {
            int? userType = _contextAccessor.HttpContext.Session.GetInt32("UserTypeId");
            if (userType != null)
            {
                if (await _peopleService.PermissionAsync(userType.Value, 1))
                {
                    await _stateRepository.CreateStateAsync(states);
                    return true;
                }
                return false;
            }
            return false;
        }

        public Task<IEnumerable<States>> GetAllStatesAsync()
        {
            return _stateRepository.GetAllStatesAsync();
        }

        public Task<States> GetStatesByIdAsync(int id)
        {
            return _stateRepository.GetStatesByIdAsync(id);
        }

        public Task SoftDeleteStateAsync(int id)
        {
            return _stateRepository.SoftDeleteStateAsync(id);
        }

        public Task UpdateStateAsync(States states)
        {
            return _stateRepository.UpdateStateAsync(states);
        }
    }
}
