using SIMYTSoacha.Model;
using SIMYTSoacha.Repositories;

namespace SIMYTSoacha.Services
{
    public interface IStateService
    {
        Task<IEnumerable<States>> GetAllStatesAsync();
        Task<States> GetStatesByIdAsync(int id);
        Task CreateStateAsync(States states);
        Task UpdateStateAsync(States states);
        Task SoftDeleteStateAsync(int id);
    }
    public class StateService : IStateService
    {
        private readonly IStateRepository _stateRepository;
        public StateService(IStateRepository state)
        {
            _stateRepository = state;
        }

        public Task CreateStateAsync(States states)
        {
            return _stateRepository.CreateStateAsync(states);
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
