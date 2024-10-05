using SIMYTSoacha.Model;
using SIMYTSoacha.Repositories;

namespace SIMYTSoacha.Services
{
    public interface IVehicleService
    {
        Task<IEnumerable<Vehicles>> GetAllVehiclesAsync();
        Task<Vehicles> GetVehiclesByIdAsync(int id);
        Task<Vehicles> CreateVehiclesAsync(int bid, int cid, string nmotor, int pid, string echasis
            , int mid, bool isdeleted);
        Task UpdateVehicleAsync(Vehicles vehicles);
        Task SoftDeleteVehicleAsync(int id);
    }
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository vehicle;
        public VehicleService(IVehicleRepository vehicleRepository)
        {
            vehicle = vehicleRepository;
        }

        public Task<Vehicles> CreateVehiclesAsync(int bid, int cid, string nmotor, int pid, string echasis, int mid, bool isdeleted)
        {
            return vehicle.CreateVehiclesAsync(bid, cid, nmotor, pid, echasis, mid, isdeleted);
        }

        public Task<IEnumerable<Vehicles>> GetAllVehiclesAsync()
        {
            return vehicle.GetAllVehiclesAsync();
        }

        public Task<Vehicles> GetVehiclesByIdAsync(int id)
        {
            return vehicle.GetVehiclesByIdAsync(id);
        }

        public Task SoftDeleteVehicleAsync(int id)
        {
           return vehicle.SoftDeleteVehicleAsync(id);
        }

        public Task UpdateVehicleAsync(Vehicles vehicles)
        {
            return vehicle.UpdateVehicleAsync(vehicles);
        }
    }
}
