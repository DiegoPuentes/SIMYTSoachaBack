using SIMYTSoacha.Model;
using SIMYTSoacha.Repositories;

namespace SIMYTSoacha.Services
{
    public interface IFinesService
    {
        Task<IEnumerable<Fines>> GetAllFinesAsync();
        Task<Fines> GetFinesByIdAsync(int id);
        Task<Fines> CreateFinesAsync(int id, int mid, int pid, bool isdeleted);
        Task UpdateFinesAsync(int id, int mid, int pid, bool isdeleted);
        Task SoftDeleteFinesAsync(int id);
    }
    public class FinesService : IFinesService
    {
        private readonly IFinesRepository _finesRepository;
        public FinesService(IFinesRepository finesRepository)
        {
            _finesRepository = finesRepository;
        }

        public Task<Fines> CreateFinesAsync(int id, int mid, int pid, bool isdeleted)
        {
            return _finesRepository.CreateFinesAsync(id, mid, pid, isdeleted);
        }

        public Task<IEnumerable<Fines>> GetAllFinesAsync()
        {
            return _finesRepository.GetAllFinesAsync();
        }

        public Task<Fines> GetFinesByIdAsync(int id)
        {
            return _finesRepository.GetFinesByIdAsync(id);
        }

        public Task SoftDeleteFinesAsync(int id)
        {
            return _finesRepository.SoftDeleteFinesAsync(id);    
        }

        public Task UpdateFinesAsync(int id, int mid, int pid, bool isdeleted)
        {
            return _finesRepository.UpdateFinesAsync(id, mid, pid, isdeleted);  
        }
    }
}
