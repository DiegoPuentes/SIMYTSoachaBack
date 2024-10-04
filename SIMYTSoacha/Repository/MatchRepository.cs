using Microsoft.EntityFrameworkCore;
using SIMYTSoacha.Context;
using SIMYTSoacha.Model;

namespace SIMYTSoacha.Repository
{
    public interface IMatchRepository
    {
        Task<IEnumerable<Matches>> GetallMatchAsync();

        Task<Matches> GetMatchesByIdAsync(int id);

        Task CreateMatchesAsync(Matches match);

        Task UpdateMatchesAsync(Matches match);

        Task DeleteMatchesAsync(int id);

    }
    public class MatchRepository : IMatchRepository
    {
        private readonly SimytDbContext _context;

        public MatchRepository(SimytDbContext context)
        {
            _context = context;

        }

        public async Task CreateMatchesAsync(Matches match)
        {
            _context.matches.Add(match);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteMatchesAsync(int id)
        {
            var match = await _context.matches.FindAsync(id);
            if ( match!= null)
            {
                match.IsDeleted = true;
                await _context.SaveChangesAsync();

            }

        }

        public async Task<IEnumerable<Matches>> GetallMatchAsync()
        {
            return await _context.matches.Where(s => !s.IsDeleted).ToListAsync();
        }

        public async Task<Matches> GetMatchesByIdAsync(int id)
        {
            return await _context.matches.FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);

        }

        public async Task UpdateMatchesAsync(Matches match)
        {
          _context.matches.Update(match);
            await _context.SaveChangesAsync();

        }
    }
}
