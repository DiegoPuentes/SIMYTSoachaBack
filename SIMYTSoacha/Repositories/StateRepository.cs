using Microsoft.EntityFrameworkCore;
using SIMYTSoacha.Context;
using SIMYTSoacha.Model;

namespace SIMYTSoacha.Repositories
{
    public interface IStateRepository
    {
        Task<IEnumerable<States>> GetAllStatesAsync();
        Task<States> GetStatesByIdAsync(int id);
        Task CreateStateAsync(States states);
        Task UpdateStateAsync(States states);
        Task SoftDeleteStateAsync(int id);
    }
    public class StateRepository : IStateRepository
    {
        private readonly SimytDbContext _context;
        public StateRepository(SimytDbContext simytDbContext)
        {
            _context = simytDbContext;
        }

        public async Task CreateStateAsync(States states)
        {
            _context.States.Add(states);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<States>> GetAllStatesAsync()
        {
            return await _context.States
                .Where(s => !s.Isdeleted)
                .ToListAsync();
        }

        public async Task<States> GetStatesByIdAsync(int id)
        {
            return await _context.States.FirstOrDefaultAsync(s => s.StateId == id && !s.Isdeleted);
        }

        public async Task SoftDeleteStateAsync(int id)
        {
            var state = await _context.States.FindAsync(id);
            if (state != null) 
            {
                state.Isdeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateStateAsync(States states)
        {
            _context.States.Update(states);
            await _context.SaveChangesAsync();
        }
    }
}
