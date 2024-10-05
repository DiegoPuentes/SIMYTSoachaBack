using SIMYTSoacha.Model;
using SIMYTSoacha.Repositories;

namespace SIMYTSoacha.Services
{
    public interface IHistoriesService
    {
        Task<IEnumerable<Histories>> GetAllHistoriesAsync();
        Task<Histories> GetHistoriesByIdAsync(int id);
        Task CreateHistoriesAsync(Histories histories);
        Task UpdateHistoriesAsync(Histories Histories);
        Task SoftDeleteHistoriesAsync(int id);
    }
    public class HistoriesService : IHistoriesService
    {
        private readonly IHistoriesRepository repository;
        public HistoriesService(IHistoriesRepository histories)
        {
            repository = histories;
        }

        public Task CreateHistoriesAsync(Histories histories)
        {
            return repository.CreateHistoriesAsync(histories);
        }

        public Task<IEnumerable<Histories>> GetAllHistoriesAsync()
        {
            return repository.GetAllHistoriesAsync();
        }

        public Task<Histories> GetHistoriesByIdAsync(int id)
        {
            return repository.GetHistoriesByIdAsync(id);
        }

        public Task SoftDeleteHistoriesAsync(int id)
        {
            return repository.SoftDeleteHistoriesAsync(id);
        }

        public Task UpdateHistoriesAsync(Histories Histories)
        {
            return repository.UpdateHistoriesAsync(Histories);
        }
    }
}
