using Microsoft.EntityFrameworkCore;
using SIMYTSoacha.Context;
using SIMYTSoacha.Model;

namespace SIMYTSoacha.Repositories
{
    public interface ITvehicleRepository
    {
        Task<IEnumerable<TypesVehicles>> GetAllTvehicleAsync();
        Task<TypesVehicles> GetTvehicleByIdAsync(int id);
        Task CreateTvehicleAsync(TypesVehicles types);
        Task UpdateTvehicleAsync(TypesVehicles types);
        Task SoftDeleteTvehicleAsync(int id);
    }
    public class TvehicleRepository : ITvehicleRepository
    {
        private readonly SimytDbContext context;
        public TvehicleRepository(SimytDbContext simytDbContext)
        {
            context = simytDbContext;
        }

        public async Task CreateTvehicleAsync(TypesVehicles types)
        {
            context.TypesVehicles.Add(types);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TypesVehicles>> GetAllTvehicleAsync()
        {
            return await context.TypesVehicles.
                Where(s => !s.Isdeleted)
                .ToListAsync();
        }

        public async Task<TypesVehicles> GetTvehicleByIdAsync(int id)
        {
            return await context.TypesVehicles.FirstOrDefaultAsync(s => s.Id == id && !s.Isdeleted);
        }

        public async Task SoftDeleteTvehicleAsync(int id)
        {
            var tvehicle = await context.TypesVehicles.FindAsync(id);
            if (tvehicle != null)
            {
                tvehicle.Isdeleted = true;
                await context.SaveChangesAsync();
            }
        }

        public async Task UpdateTvehicleAsync(TypesVehicles types)
        {
            context.TypesVehicles.Update(types);
            await context.SaveChangesAsync();
        }
    }
}
