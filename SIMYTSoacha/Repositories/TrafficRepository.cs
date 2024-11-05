using Microsoft.EntityFrameworkCore;
using SIMYTSoacha.Context;
using SIMYTSoacha.Model;

namespace SIMYTSoacha.Repositories
{
    public interface ITrafficRepository
    {
        Task<IEnumerable<TrafficLicenses>> GetAllTrafficLicensesAsync();
        Task<TrafficLicenses> GetTrafficLicensesByIdAsync(int id);
        Task<TrafficLicenses> CreateTrafficLicensesAsync(string plate, int vstate, int tid,
            int vid, int pid, bool isdeleted);
        Task UpdateTrafficLicensesAsync(TrafficLicenses trafficLicenses);
        Task SoftDeleteTrafficLicensesAsync(int id);
    }
    public class TrafficRepository : ITrafficRepository
    {
        private readonly SimytDbContext context;
        public TrafficRepository(SimytDbContext _context)
        {
            context = _context;
        }

        public async Task<TrafficLicenses> CreateTrafficLicensesAsync(string plate, int vstate, int tid, int vid, int pid, bool isdeleted)
        {
            TrafficLicenses traffic = new TrafficLicenses
            {
                Plate = plate,
                VstatesId = vstate,
                States = null,
                TserviceId = tid,
                Services = null,
                TvehicleId = vid,
                Vehicles = null,
                ProcedureId = pid,
                Procedures = null,
                Isdeleted = isdeleted
            };
            context.TrafficLicenses.Add(traffic);
            await context.SaveChangesAsync();
            return traffic;
        }

        public async Task<IEnumerable<TrafficLicenses>> GetAllTrafficLicensesAsync()
        {
            return await context.TrafficLicenses
                .Where(s => !s.Isdeleted)
                .Include(s => s.States)
                .Include(se => se.Services)
                .Include(v => v.Vehicles)
                .Include(p => p.Procedures)
                .ToListAsync();
        }

        public async Task<TrafficLicenses> GetTrafficLicensesByIdAsync(int id)
        {
            return await context.TrafficLicenses
                .FirstOrDefaultAsync(s => s.TlicensesId == id && !s.Isdeleted);
        }

        public async Task SoftDeleteTrafficLicensesAsync(int id)
        {
            var traffic = await context.TrafficLicenses.FindAsync(id);
            if (traffic != null)
            {
                traffic.Isdeleted = true;
                await context.SaveChangesAsync();
            }
        }

        public async Task UpdateTrafficLicensesAsync(TrafficLicenses trafficLicenses)
        {
            context.TrafficLicenses.Update(trafficLicenses);
            await context.SaveChangesAsync();
        }
    }
}
