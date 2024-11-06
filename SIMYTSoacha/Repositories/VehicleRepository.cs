using Microsoft.EntityFrameworkCore;
using SIMYTSoacha.Context;
using SIMYTSoacha.Model;

namespace SIMYTSoacha.Repositories
{
    public interface IVehicleRepository
    {
        Task<IEnumerable<Vehicles>> GetAllVehiclesAsync();
        Task<Vehicles> GetVehiclesByIdAsync(int id);
        Task<Vehicles> CreateVehiclesAsync(int bid, int cid, string nmotor, int pid, string echasis
            , int mid, bool isdeleted);
        Task UpdateVehicleAsync(Vehicles vehicles);
        Task SoftDeleteVehicleAsync(int id);
    }
    public class VehicleRepository : IVehicleRepository
    {
        private readonly SimytDbContext context;
        public VehicleRepository(SimytDbContext simytDbContext)
        {
            context = simytDbContext;
        }

        public async Task<Vehicles> CreateVehiclesAsync(int bid, int cid, string nmotor, int pid, string echasis, int mid, bool isdeleted)
        {
            Vehicles vehicle = new Vehicles
            {
                BrandId = bid,
                Brand = null,
                ColorId = cid,
                Color = null,
                Nmotor = nmotor,
                PeopleId = pid,
                People = null,
                Echasis = echasis,
                MlineId = mid,
                Models = null,
                Isdeleted = isdeleted
            };
            context.Vehicles.Add(vehicle);
            await context.SaveChangesAsync();
            return vehicle;
        }

        public async Task<IEnumerable<Vehicles>> GetAllVehiclesAsync()
        {
            return await context.Vehicles.Where(s => !s.Isdeleted)
                .Include(b => b.Brand)
                .Include(c => c.Color)
                .Include(p => p.People)
                .Include(p => p.Models)
                .ToListAsync();
        }

        public async Task<Vehicles> GetVehiclesByIdAsync(int id)
        {
            return await context.Vehicles.FirstOrDefaultAsync(s => s.Id == id && !s.Isdeleted);
        }

        public async Task SoftDeleteVehicleAsync(int id)
        {
            var vehicle = await context.Vehicles.FindAsync(id);
            if (vehicle != null)
            {
                vehicle.Isdeleted = true;
                await context.SaveChangesAsync();
            }
        }

        public async Task UpdateVehicleAsync(Vehicles vehicles)
        {
            context.Vehicles.Update(vehicles);
            await context.SaveChangesAsync();
        }
    }
}
