using Microsoft.EntityFrameworkCore;
using SIMYTSoacha.Context;
using SIMYTSoacha.Model;

namespace SIMYTSoacha.Repositories
{
    public interface IDriverRepository
    {
        Task<IEnumerable<DriverLicenses>> GetAllDriverAsync();
        Task<DriverLicenses> GetDriverByIdAsync(int id);
        Task<DriverLicenses> CreateDriverAsync(int nlicense, int Eid, DateTime date, 
            int Sid, int Rid, int Pid, bool isdeleted);
        Task UpdateDriverAsync(DriverLicenses driverLicenses);
        Task SoftDeleteDriverAsync(int id);
    }
    public class DriverRepository : IDriverRepository
    {
        private readonly SimytDbContext _simytDbContext;
        public DriverRepository(SimytDbContext simytDbContext)
        {
            _simytDbContext = simytDbContext;
        }

        public async Task<DriverLicenses> CreateDriverAsync(int nlicense, int Eid, DateTime date,
            int Sid, int Rid, int Pid, bool isdeleted)
        {
            DriverLicenses driver = new DriverLicenses 
            { 
                Nlicense = nlicense,
                EcenterId = Eid,
                Ecenters = null,
                DateIssue = date,
                StateId = Sid,
                States = null,
                RestrictionId = Rid,
                Restrictions = null,
                ProcedureId = Pid,
                Procedures = null,
                Isdeleted = isdeleted
            };
            _simytDbContext.DriverLicenses.Add(driver);
            await _simytDbContext.SaveChangesAsync();
            return driver;
        }

        public async Task<IEnumerable<DriverLicenses>> GetAllDriverAsync()
        {
            return await _simytDbContext.DriverLicenses
                .Where(s => !s.Isdeleted)
                .Include(e => e.Ecenters)
                .Include(s => s.States)
                .Include(r => r.Restrictions)
                .Include(p => p.Procedures)
                .ToListAsync();
        }

        public async Task<DriverLicenses> GetDriverByIdAsync(int id)
        {
            return await _simytDbContext.DriverLicenses
                .FirstOrDefaultAsync(s => s.Id == id && !s.Isdeleted);
        }

        public async Task SoftDeleteDriverAsync(int id)
        {
            var driver = await _simytDbContext.DriverLicenses.FindAsync(id);
            if (driver != null)
            {
                driver.Isdeleted = true;
                await _simytDbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateDriverAsync(DriverLicenses driverLicenses)
        {
            _simytDbContext.DriverLicenses.Update(driverLicenses);
            await _simytDbContext.SaveChangesAsync();
        }
    }
}
