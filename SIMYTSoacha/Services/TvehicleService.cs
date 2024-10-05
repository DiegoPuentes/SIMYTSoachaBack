using SIMYTSoacha.Model;
using SIMYTSoacha.Repositories;

namespace SIMYTSoacha.Services
{
    public interface ITvehicleService
    {
        Task<IEnumerable<TypesVehicles>> GetAllTvehicleAsync();
        Task<TypesVehicles> GetTvehicleByIdAsync(int id);
        Task CreateTvehicleAsync(TypesVehicles types);
        Task UpdateTvehicleAsync(TypesVehicles types);
        Task SoftDeleteTvehicleAsync(int id);
    }
    public class TVehicleService : ITvehicleService
    {
        private readonly ITvehicleRepository _vehicleRepository;
        public TVehicleService(ITvehicleRepository tvehicle)
        {
            _vehicleRepository = tvehicle;
        }

        public Task CreateTvehicleAsync(TypesVehicles types)
        {
            return _vehicleRepository.CreateTvehicleAsync(types);
        }

        public Task<IEnumerable<TypesVehicles>> GetAllTvehicleAsync()
        {
            return _vehicleRepository.GetAllTvehicleAsync();
        }

        public Task<TypesVehicles> GetTvehicleByIdAsync(int id)
        {
            return _vehicleRepository.GetTvehicleByIdAsync(id);
        }

        public Task SoftDeleteTvehicleAsync(int id)
        {
            return _vehicleRepository.SoftDeleteTvehicleAsync(id);
        }

        public Task UpdateTvehicleAsync(TypesVehicles types)
        {
            return _vehicleRepository.UpdateTvehicleAsync(types);
        }
    }
}
