using SIMYTSoacha.Model;
using SIMYTSoacha.Repositories;

namespace SIMYTSoacha.Services
{
    public interface ILevelsService
    {
        Task<IEnumerable<Levels>> GetAllLevelsAsync();
        Task<Levels> GetLevelsByIdAsync(int id);
        Task CreateLevelsAsync(Levels levels);
        Task SoftDeleteLevelsAsync(int id);
        Task UpdateLevelsAsync(Levels levels);
    }
    public class LevelService : ILevelsService
    {
        private readonly ILevelsRepository repository;
        public LevelService(ILevelsRepository levelsRepository)
        {
            repository = levelsRepository;
        }

        public Task CreateLevelsAsync(Levels levels)
        {
            return repository.CreateLevelsAsync(levels);
        }

        public Task<IEnumerable<Levels>> GetAllLevelsAsync()
        {
            return repository.GetAllLevelsAsync();
        }

        public Task<Levels> GetLevelsByIdAsync(int id)
        {
            return repository.GetLevelsByIdAsync(id);
        }

        public Task SoftDeleteLevelsAsync(int id)
        {
            return repository.SoftDeleteLevelsAsync(id);
        }

        public Task UpdateLevelsAsync(Levels levels)
        {
            return repository.UpdateLevelsAsync(levels);
        }
    }
}
