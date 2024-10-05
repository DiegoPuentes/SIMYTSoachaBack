using Microsoft.EntityFrameworkCore;
using SIMYTSoacha.Context;
using SIMYTSoacha.Model;

namespace SIMYTSoacha.Repositories
{
    public interface IInfractionRepository
    {
        Task<IEnumerable<Infractions>> GetAllInfractionsAsync();
        Task<Infractions> GetInfractionsByIdAsync(int id);
        Task CreateInfractionAsync(Infractions infractions);
        Task UpdateInfractionAsync(Infractions infractions);
        Task SoftDeleteInfractionAsync(int id);
    }
    public class InfractionRepository : IInfractionRepository
    {
        private readonly SimytDbContext _simytDbContext;
        public InfractionRepository(SimytDbContext simytDbContext)
        {
            _simytDbContext = simytDbContext;
        }

        public async Task CreateInfractionAsync(Infractions infractions)
        {
            _simytDbContext.Infractions.Add(infractions);
            await _simytDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Infractions>> GetAllInfractionsAsync()
        {
            return await _simytDbContext.Infractions
                .Where(s => !s.Isdeleted)
                .ToListAsync();
        }

        public async Task<Infractions> GetInfractionsByIdAsync(int id)
        {
            return await _simytDbContext.Infractions
                .FirstOrDefaultAsync(s => s.InfractionId == id && !s.Isdeleted);
        }

        public async Task SoftDeleteInfractionAsync(int id)
        {
            var infra = await _simytDbContext.Infractions.FindAsync(id);
            if (infra != null) 
            {
                infra.Isdeleted = true;
                await _simytDbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateInfractionAsync(Infractions infractions)
        {
            _simytDbContext.Infractions.Update(infractions);
            await _simytDbContext.SaveChangesAsync();
        }
    }
}
