using SIMYTSoacha.Model;
using SIMYTSoacha.Repositories;

namespace SIMYTSoacha.Services
{
    public interface IMxLService
    {
        Task<IEnumerable<ModelXLine>> GetAllAsync();
        Task CreateAsync(ModelXLine model);
    }
    public class MxLService : IMxLService
    {
        private readonly IMxLRepository _repo;
        public MxLService(IMxLRepository mxLRepository)
        {
            _repo = mxLRepository;
        }

        public Task CreateAsync(ModelXLine model)
        {
            return _repo.CreateAsync(model);
        }

        public Task<IEnumerable<ModelXLine>> GetAllAsync()
        {
            return _repo.GetAllAsync();
        }
    }
}
