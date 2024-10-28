using SIMYTSoacha.Model;
using SIMYTSoacha.Repositories;

namespace SIMYTSoacha.Services
{
    public interface ITvehicleService
    {
        Task<IEnumerable<TypesVehicles>> GetAllTvehicleAsync();
        Task<TypesVehicles> GetTvehicleByIdAsync(int id);
        Task<bool> CreateTvehicleAsync(TypesVehicles types);
        Task UpdateTvehicleAsync(TypesVehicles types);
        Task SoftDeleteTvehicleAsync(int id);
    }
    public class TVehicleService : ITvehicleService
    {
        private readonly ITvehicleRepository _vehicleRepository;
        private readonly IPeopleService _peopleService;
        private readonly IHttpContextAccessor _contextAccessor;
        public TVehicleService(ITvehicleRepository tvehicle, IPeopleService peopleService,
            IHttpContextAccessor httpContextAccessor)
        {
            _vehicleRepository = tvehicle;
            _peopleService = peopleService;
            _contextAccessor = httpContextAccessor;
        }

        public async Task<bool> CreateTvehicleAsync(TypesVehicles types)
        {
            int? userType = _contextAccessor.HttpContext.Session.GetInt32("UserTypeId");
            if (userType != null)
            {
                if (await _peopleService.PermissionAsync(userType.Value, 1))
                {
                    await _vehicleRepository.CreateTvehicleAsync(types);
                    return true;
                }
                return false;
            }
            return false;
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
