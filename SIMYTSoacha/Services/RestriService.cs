using SIMYTSoacha.Model;
using SIMYTSoacha.Repositories;

namespace SIMYTSoacha.Services
{
    public interface IRestriService
    {
        Task<IEnumerable<Restrictions>> GetAllRestriAsync();
        Task<Restrictions> GetRestriByIdAsync(int id);
        Task CreateRestriAsync(Restrictions restri);
        Task UpdateRestriAsync(Restrictions restri);
        Task SoftDeleteRestriAsync(int id);
    }

    public class RestriService : IRestriService
    {
        private readonly IRestrictionRepository _restrictionRepository;
        public RestriService(IRestrictionRepository restrictionRepository)
        {
            _restrictionRepository = restrictionRepository;
        }

        public Task CreateRestriAsync(Restrictions restri)
        {
            return _restrictionRepository.CreateRestriAsync(restri);
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
