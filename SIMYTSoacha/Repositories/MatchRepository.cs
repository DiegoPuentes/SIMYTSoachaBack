using Microsoft.EntityFrameworkCore;
using SIMYTSoacha.Context;
using SIMYTSoacha.Model;
using System.Text.RegularExpressions;

namespace SIMYTSoacha.Repositories
{
    public interface IMatchRepository
    {
        Task<IEnumerable<Matches>> GetallMatchAsync();
        Task<Matches> GetMatchesByIdAsync(int id);
        Task<Matches> CreateMatchesAsync(int people, DateTime date, bool isdeleted);
        Task UpdateMatchesAsync(Matches match);
        Task DeleteMatchesAsync(int id);
    }
    public class MatchRepository : IMatchRepository
    {
        private readonly SimytDbContext _context;
        public MatchRepository(SimytDbContext simytDbContext)
        {
            _context = simytDbContext;
        }

        public async Task<Matches> CreateMatchesAsync(int people, DateTime date, bool isdeleted)
        {
            Matches match = new Matches
            {
                PeopleId = people,
                People = null,
                Date = date,
                IsDeleted = isdeleted
            };
            _context.Matches.Add(match);
            await _context.SaveChangesAsync();
            return match;
        }

        public async Task DeleteMatchesAsync(int id)
        {
            var match = await _context.Matches.FindAsync(id);
            if (match != null)
            {
                match.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Matches>> GetallMatchAsync()
        {
            return await _context.Matches.Where(s => !s.IsDeleted).ToListAsync();
        }

        public async Task<Matches> GetMatchesByIdAsync(int id)
        {
            return await _context.Matches.FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);
        }

        public async Task UpdateMatchesAsync(Matches match)
        {
            _context.Matches.Update(match);
            await _context.SaveChangesAsync();
        }
    }
}
