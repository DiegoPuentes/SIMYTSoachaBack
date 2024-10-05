using SIMYTSoacha.Model;
using SIMYTSoacha.Repositories;

namespace SIMYTSoacha.Services
{
    public interface ICenterService
    {
        Task<IEnumerable<Ecenters>> GetAllCenterAsync();
        Task<Ecenters> GetCenterByIdAsync(int id);
        Task CreateCenterAsync(Ecenters ecenters);
        Task UpdateCenterAsync(Ecenters ecenters);
        Task SoftDeleteCenterAsync(int id);
    }

    public class CenterService : ICenterService
    {
        private readonly ICenterRepository _centerRepository;
        public CenterService(ICenterRepository centerRepository)
        {
            _centerRepository = centerRepository;
        }

        public Task CreateCenterAsync(Ecenters ecenters)
        {
            return _centerRepository.CreateCenterAsync(ecenters);
        }

        public Task<IEnumerable<Ecenters>> GetAllCenterAsync()
        {
            return _centerRepository.GetAllCenterAsync();
        }

        public Task<Ecenters> GetCenterByIdAsync(int id)
        {
            return _centerRepository.GetCenterByIdAsync(id);
        }

        public Task SoftDeleteCenterAsync(int id)
        {
            return _centerRepository.SoftDeleteCenterAsync(id);
        }

        public Task UpdateCenterAsync(Ecenters ecenters)
        {
            return _centerRepository.UpdateCenterAsync(ecenters);
        }
    }
}
