using Microsoft.EntityFrameworkCore;
using SIMYTSoacha.Context;
using SIMYTSoacha.Model;

namespace SIMYTSoacha.Repositories
{
    public interface IRequestRepository
    {
        Task<IEnumerable<Requests>> GetAllRequestsAsync();
        Task<Requests> GetRequestsByIdAsync(int id);
        Task<Requests> CreateRequestAsync(int pid, DateTime date, int officer, bool isde);
        Task UpdateRequestAsync(Requests requests);
        Task SoftDeleteRequestsByIdAsync(int id);
    }
    public class RequestRepository : IRequestRepository
    {
        private readonly SimytDbContext _simytDbContext;
        public RequestRepository(SimytDbContext simytDbContext)
        {
            _simytDbContext = simytDbContext;
        }

        public async Task<Requests> CreateRequestAsync(int pid, DateTime date, int officer, bool isde)
        {
            Requests requests = new Requests
            {
                PeopleId = pid,
                People = null,
                Request = date,
                OfficerId = officer,
                Officer = null,
                Isdeleted = isde
            };
            _simytDbContext.Requests.Add(requests);
            await _simytDbContext.SaveChangesAsync();
            return requests;
        }

        public async Task<IEnumerable<Requests>> GetAllRequestsAsync()
        {
            return await _simytDbContext.Requests
                .Where(s => !s.Isdeleted)
                .Include(s => s.People)
                .Include(p => p.Officer)
                .ToListAsync();
        }

        public async Task<Requests> GetRequestsByIdAsync(int id)
        {
            return await _simytDbContext.Requests.
                FirstOrDefaultAsync(s => s.RequestId == id && !s.Isdeleted);
        }

        public async Task SoftDeleteRequestsByIdAsync(int id)
        {
            var re = await _simytDbContext.Requests.FindAsync(id);
            if (re != null)
            {
                re.Isdeleted = true;
                await _simytDbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateRequestAsync(Requests requests)
        {
            _simytDbContext.Requests.Update(requests);
            await _simytDbContext.SaveChangesAsync();
        }
    }
}
