using SIMYTSoacha.Model;
using SIMYTSoacha.Repositories;

namespace SIMYTSoacha.Services
{
    public interface IImpositionService
    {
        Task<IEnumerable<Mimpositions>> GetAllMimpositionsAsync();
        Task<Mimpositions> GetMimpositionsByIdAsync(int id);
        Task CreateMimpositionsAsync(Mimpositions mimpositions);
        Task UpdateMimpositionAsync(Mimpositions mimpositions);
        Task SoftDeleteMimpositionsAsync(int id);
    }
    public class ImpositionService : IImpositionService
    {
        private readonly IImpositionRepository _repository;
        public ImpositionService(IImpositionRepository impositionRepository)
        {
            _repository = impositionRepository;
        }

        public Task CreateMimpositionsAsync(Mimpositions mimpositions)
        {
            return _repository.CreateMimpositionsAsync(mimpositions);
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
