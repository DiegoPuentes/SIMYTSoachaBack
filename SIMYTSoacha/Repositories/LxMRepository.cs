using Microsoft.EntityFrameworkCore;
using SIMYTSoacha.Context;
using SIMYTSoacha.Model;

namespace SIMYTSoacha.Repositories
{
    public interface ILxMRepository
    {
        Task<IEnumerable<LevelsxMatches>> GetAllLxMAsync();
        Task<LevelsxMatches> CreateLxMAsync(int id, int iid, int scored, bool isdeleted);
    }
    public class LxMRepository : ILxMRepository
    {
        private readonly SimytDbContext context;
        public LxMRepository(SimytDbContext _context)
        {
            context = _context;
        }

        public async Task<LevelsxMatches> CreateLxMAsync(int id, int iid, int scored, bool isdeleted)
        {
            LevelsxMatches lxm = new LevelsxMatches
            {
                LevelId = id,
                Levels = null,
                MatchId = id,
                Matchs = null,
                Scored = scored,
                IsDeleted = isdeleted 
            };

            context.LevelsxMatches.Add(lxm);
            await context.SaveChangesAsync();
            return lxm;
        }

        public async Task<IEnumerable<LevelsxMatches>> GetAllLxMAsync()
        {
            return await context.LevelsxMatches
                .Where(s => !s.IsDeleted)
                .ToListAsync();
        }
    }
}
