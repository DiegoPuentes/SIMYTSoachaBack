using SIMYTSoacha.Model;
using SIMYTSoacha.Repositories;

namespace SIMYTSoacha.Services
{
    public interface ITserviceService
    {
        Task<IEnumerable<TypesServices>> GetAllTserviceAsync();
        Task<TypesServices> GetTserviceByIdAsync(int id);
        Task CreateTserviceAsync(TypesServices types);
        Task UpdateTserviceAsync(TypesServices types);
        Task SoftDeleteTserviceAsync(int id);
    }
    public class TserviceService : ITserviceService
    {
        private readonly ITserviceRepository _repository;
        public TserviceService(ITserviceRepository tserviceRepository)
        {
            _repository = tserviceRepository;
        }

        public Task CreateTserviceAsync(TypesServices types)
        {
            return _repository.CreateTserviceAsync(types);
        }

        public Task<IEnumerable<TypesServices>> GetAllTserviceAsync()
        {
            return _repository.GetAllTserviceAsync();
        }

        public Task<TypesServices> GetTserviceByIdAsync(int id)
        {
            return _repository.GetTserviceByIdAsync(id);
        }

        public Task SoftDeleteTserviceAsync(int id)
        {
            return _repository.SoftDeleteTserviceAsync(id);
        }

        public Task UpdateTserviceAsync(TypesServices types)
        {
            return _repository.UpdateTserviceAsync(types);
        }
    }
}
