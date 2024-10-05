using SIMYTSoacha.Model;
using SIMYTSoacha.Repositories;

namespace SIMYTSoacha.Services
{
    public interface IInfractionService
    {
        Task<IEnumerable<Infractions>> GetAllInfraAsync();
        Task<Infractions> GetInfraByIdAsync(int id);
        Task CreateInfraAsync(Infractions infra);
        Task UpdateInfraAsync(Infractions infra);
        Task SoftDeleteInfraAsync(int id);
    }
    public class InfractionService : IInfractionService
    {
        private readonly IInfractionRepository _repository;
        public InfractionService(IInfractionRepository infractionRepository)
        {
            _repository = infractionRepository;
        }

        public Task CreateInfraAsync(Infractions infra)
        {
            return _repository.CreateInfractionAsync(infra);
        }

        public Task<IEnumerable<Infractions>> GetAllInfraAsync()
        {
            return _repository.GetAllInfractionsAsync();
        }

        public Task<Infractions> GetInfraByIdAsync(int id)
        {
            return _repository.GetInfractionsByIdAsync(id);
        }

        public Task SoftDeleteInfraAsync(int id)
        {
            return _repository.SoftDeleteInfractionAsync(id);
        }

        public Task UpdateInfraAsync(Infractions infra)
        {
            return _repository.UpdateInfractionAsync(infra);
        }
    }
}
