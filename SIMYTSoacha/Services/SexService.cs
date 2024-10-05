using SIMYTSoacha.Model;
using SIMYTSoacha.Repositories;

namespace SIMYTSoacha.Services
{
    public interface ISexService
    {
        Task<IEnumerable<Sex>> GetAllSexAsync();
        Task<Sex> GetSexByIdAsync(int id);
        Task CreateSexAsync(Sex sex);
        Task UpdateSexAsync(Sex sex);
        Task DeleteSexByIdAsync(int id);
    }
    public class SexService : ISexService
    {
        private readonly ISexRepository _repository;
        public SexService(ISexRepository sexRepository)
        {
            _repository = sexRepository;
        }

        public Task CreateSexAsync(Sex sex)
        {
            return _repository.CreateSexAsync(sex);
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
